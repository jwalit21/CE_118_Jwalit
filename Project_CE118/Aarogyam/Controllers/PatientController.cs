using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aarogyam.Models;
using Aarogyam.Models.IRepositories;
using Aarogyam.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Aarogyam.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository patientRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ICitizenRepository citizenRepository;
        private readonly AppDbContext context;

        public PatientController(
            AppDbContext context,
            IPatientRepository patientRepository,
            ICitizenRepository citizenRepository,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.citizenRepository = citizenRepository;
            this.patientRepository = patientRepository;
        }

        [Authorize(Roles = "Hospital")]
        public IActionResult Index()
        {
            var SuccessMessage = TempData["SuccessMessage"];
            if (SuccessMessage != null)
            {
                ViewBag.SuccessMessage = SuccessMessage;
            }
            var ErrorMessage = TempData["ErrorMessage"];
            if (ErrorMessage != null)
            {
                ViewBag.ErrorMessage = ErrorMessage;
            }

            var logged_usr_id = signInManager.UserManager.GetUserId(User);
            var logged_user_hospital_id = userManager.Users
                .Where(usr => usr.Id == logged_usr_id)
                .FirstOrDefault()
                .HospitalId;

            var all_patients = context.Patients.Where(pat => pat.Hospital.HospitalId == logged_user_hospital_id).ToList();
            List<PatientList> patientLists = new List<PatientList>();

            foreach (var item in all_patients)
            {
                var citizen = userManager.Users.Where(us => us.CitizenId == item.CitizenId).FirstOrDefault();
                patientLists.Add(new PatientList()
                {
                    CheckupData = citizen.CheckupData,
                    PatientId = item.PatientId,
                    CitizenId = citizen.CitizenId,
                    Email = citizen.Email,
                    Mobile = citizen.Mobile,
                    Name = citizen.Name,
                });
            }

            return View(patientLists);
        }

        [Authorize(Roles = "Hospital")]
        [HttpGet]
        public IActionResult Create()
        {
            var logged_usr_id = signInManager.UserManager.GetUserId(User);
            var logged_user_hospital = userManager.Users
                .Where(usr => usr.Id == logged_usr_id)
                .FirstOrDefault();

            var all_patients = context.Patients.Where(pat => pat.Hospital.HospitalId == logged_user_hospital.HospitalId).Count();
            var all_requested_patients = context.RequestPatients.Where(rp => rp.hospitalId == logged_user_hospital.HospitalId).Count();

            if ((all_patients + all_requested_patients) >= logged_user_hospital.MaxBeds)
            {
                //add error
                TempData["ErrorMessage"] = "Sorry !! All Beds are full in the Hospital!";
                return RedirectToAction("Index", "Patient");
            }

            var citizen_hospital_usr = context.CitizenHospitals.Where(ch => ch.Hospital.HospitalId == logged_user_hospital.HospitalId).ToList();
            List<ApplicationUser> citizen_user_list = new List<ApplicationUser>();
            var citizens = citizenRepository.GetAllCitizens();


            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var ch in citizen_hospital_usr)
                citizen_user_list.Add(citizens.Where(usr => usr.CitizenId == ch.CitizenId).FirstOrDefault());

            foreach (var item in citizen_user_list)
                selectListItems.Add(new SelectListItem { Text = item.Name + " " + item.Email, Value = item.CitizenId.ToString() });

            ViewBag.citizen_list = selectListItems;
            return View();
        }

        [Authorize(Roles = "Hospital")]
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                var logged_usr_id = signInManager.UserManager.GetUserId(User);
                var logged_user_hospital = userManager.Users
                    .Where(usr => usr.Id == logged_usr_id)
                    .FirstOrDefault();
                patient.Hospital = logged_user_hospital;

                var already_patient = patientRepository.GetPatientByCitizenId(patient.CitizenId);
                if(already_patient != null)
                {
                    //already citizen is patient
                    TempData["ErrorMessage"] = "You are already a Patient and already Hospitalized!";
                    return RedirectToAction("Index");
                }

                Patient newPatient = patientRepository.Add(patient);
                TempData["SuccessMessage"] = "Patient Hospitalized Successfully!";
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Hospital")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Patient patient = patientRepository.GetPatient(id);
            if (patient == null)
            {
                TempData["ErrorMessage"] = "Patient not found!";
                return RedirectToAction("Index", "Patient");
            }

            var logged_usr_id = signInManager.UserManager.GetUserId(User);
            var logged_user_hospital_id = userManager.Users
                .Where(usr => usr.Id == logged_usr_id)
                .FirstOrDefault()
                .HospitalId;

            if (patient.Hospital.HospitalId != logged_user_hospital_id)
            {
                TempData["ErrorMessage"] = "Access Denied!";
                return RedirectToAction("Index","Patient");
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Patient patient = patientRepository.GetPatient(id);
            patientRepository.Delete(patient.PatientId);
            TempData["SuccessMessage"] = "Patient DeHospitalized Successfully!";
            return RedirectToAction("Index", "Patient");
        }

        [HttpGet]
        [Authorize(Roles ="Hospital")]
        public IActionResult Details(int id)
        {
            //dummy record for checking
            //Student s = new Student { StudentID = Student_ID, cpi = 92, email = "hhh@h.com", mobile = "9998889998", Name = "j", Subjects = null };

            Patient patient = patientRepository.GetPatient(id);
            if (patient == null)
            {
                TempData["ErrorMessage"] = "Patient Data not found!";
                return RedirectToAction("Index", "Patient");
            }

            var logged_usr_id = signInManager.UserManager.GetUserId(User);
            var logged_user_hospital_id = userManager.Users
                .Where(usr => usr.Id == logged_usr_id)
                .FirstOrDefault()
                .HospitalId;

            if (patient.Hospital.HospitalId != logged_user_hospital_id)
            {
                TempData["ErrorMessage"] = "Access Denied!";
                return RedirectToAction("Index", "Patient");
            }

            var citizen = userManager.Users.Where(us => us.CitizenId == patient.CitizenId).FirstOrDefault();
            var patient_citizen = new PatientList()
            {
                CitizenId = patient.CitizenId,
                PatientId = patient.PatientId,
                CheckupData = citizen.CheckupData,
                Name = citizen.Name,
                Email = citizen.Email,
                Mobile = citizen.Mobile,
            };

            return View(patient_citizen);
        }


        [HttpGet]
        [Authorize(Roles = "Hospital")]
        public IActionResult RegisterCitizenAsPatient()
        {
            var logged_usr_id = signInManager.UserManager.GetUserId(User);
            var logged_user_hospital = userManager.Users
                .Where(usr => usr.Id == logged_usr_id)
                .FirstOrDefault();

            var patient_hospial_count = context.Patients.Where(pat => pat.Hospital.HospitalId == logged_user_hospital.HospitalId).Count();
            var requested_patients_count = context.RequestPatients.Where(rp => rp.hospitalId == logged_user_hospital.HospitalId).Count();

            if ((patient_hospial_count + requested_patients_count) >= logged_user_hospital.MaxBeds )
            {
                //addd errors
                //beds are full
                TempData["ErrorMessage"] = "Sorry !! All Beds are full in the Hospital!";
                return RedirectToAction("Index", "Patient");
            }

            ViewBag.hospital_id = logged_user_hospital.HospitalId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCitizenAsPatient(RegisterCitizen registerCitizen)
        {
            ApplicationUser Citizen_with_max_ID = citizenRepository.GetMaxCitizen();
            if (ModelState.IsValid)
            {
                //copy data from registerviewmodel to identityuser
                var user = new ApplicationUser
                {
                    //CitizenId = 0,
                    CitizenId = Citizen_with_max_ID.CitizenId + 1,
                    UserName = registerCitizen.Email,
                    Email = registerCitizen.Email,
                    Name = registerCitizen.Name,
                    Gender = registerCitizen.Gender,
                    Mobile = registerCitizen.Mobile,
                    IsCitizen = true,
                    BirthDate = DateTime.Now,
                    Bloodgroup = registerCitizen.Bloodgroup,
                    Height = registerCitizen.Height,
                    Weight = registerCitizen.Weight,
                    CheckupData = registerCitizen.CheckupData,
                    State = registerCitizen.State,
                    City = registerCitizen.City,
                    Address = registerCitizen.Address,
                };

                CitizenHospital citizenHospital = new CitizenHospital();

                citizenHospital.Hospital = userManager.Users
                    .Where(user => user.IsHospital == true)
                    .Where(us => us.HospitalId == registerCitizen.Hospital_id_select)
                    .FirstOrDefault();

                citizenHospital.CitizenId = Citizen_with_max_ID.CitizenId + 1;
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.CitizenHospitals.Add(citizenHospital);
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CitizenHospitals ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CitizenHospitals OFF;");
                    transaction.Commit();
                }

                var result = await userManager.CreateAsync(user, registerCitizen.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Citizen");
                    var max_patient = patientRepository.GetMaxPatient();
                    Patient patient = new Patient();
                    patient.PatientId = max_patient.PatientId + 1;
                    patient.CitizenId = user.CitizenId;
                    patient.Hospital = userManager.Users
                                        .Where(user => user.IsHospital == true)
                                        .Where(us => us.HospitalId == registerCitizen.Hospital_id_select)
                                        .FirstOrDefault();

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Patients.Add(patient);
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Patients ON;");
                        context.SaveChanges();
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Patients OFF;");
                        transaction.Commit();
                    }

                    TempData["SuccessMessage"] = "Citizen Registered & Hospitalized Successfully!";
                    return RedirectToAction("Index", "Patient");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerCitizen);
        }

        [HttpGet]
        [Authorize(Roles = "Hospital")]
        //remaining
        public IActionResult PatientCheckupDataUpdate(int Id)
        {
            var logged_usr_id = signInManager.UserManager.GetUserId(User);
            var logged_user_hospital_id = userManager.Users
                .Where(usr => usr.Id == logged_usr_id)
                .FirstOrDefault()
                .HospitalId;

            var patient = patientRepository.GetPatient(Id);
            if(patient==null)
            {
                TempData["ErrorMessage"] = "Patient not found!";
                return RedirectToAction("Index", "Patient");
            }

            if (patient.Hospital.HospitalId != logged_user_hospital_id)
            {
                TempData["ErrorMessage"] = "Access Denied!";
                return RedirectToAction("Index", "Patient");
            }

            var citizen = userManager.Users.Where(us => us.CitizenId == patient.CitizenId).FirstOrDefault();
            var patientCheckupData = new PatientCheckupData()
            {
                ID = citizen.Id,
                CheckupData = citizen.CheckupData,
            };
            return View(patientCheckupData);
        }

        [HttpPost]
        [Authorize(Roles = "Hospital")]
        //remaining
        public async Task<IActionResult> PatientCheckupDataUpdate(PatientCheckupData patientCheckupData)
        {
            var patient = patientRepository.GetPatient(Int32.Parse(patientCheckupData.ID));
            var user_identity = userManager.Users.Where(ui => ui.CitizenId == patient.CitizenId).FirstOrDefault();
            user_identity.CheckupData = patientCheckupData.CheckupData;

            IdentityResult task = await userManager.UpdateAsync(user_identity);
            if(task.Succeeded)
            {
                TempData["SuccessMessage"] = "Checkup data Updated Successfully!";
                return RedirectToAction("Index", "Patient");
            }

            //add error
            TempData["ErrorMessage"] = "Error Occured!";
            return RedirectToAction("Index", "Patient");

        }
    }
}
