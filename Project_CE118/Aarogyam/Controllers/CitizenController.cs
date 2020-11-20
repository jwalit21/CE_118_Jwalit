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
using Microsoft.EntityFrameworkCore;

namespace Aarogyam.Controllers
{
    public class CitizenController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext context;
        private readonly IPatientRepository patientRepository;

        public CitizenController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            AppDbContext context,
            IPatientRepository patientRepository)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.patientRepository = patientRepository;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Citizen")]
        public IActionResult Dashboard()
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

            ViewBag.todays_covid_data = context.CovidDatas.Where(cd => (cd.Date.Day == DateTime.Now.Day && cd.Date.Month == DateTime.Now.Month && cd.Date.Year == DateTime.Now.Year)).FirstOrDefault();
            ViewBag.advisories = context.Advisories.Count();

            return View();
        }

        [Authorize(Roles = "Citizen")]
        public async Task<IActionResult> Details()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            RegisterCitizen rc = new RegisterCitizen()
            {
                Address = usr.Address,
                BirthDate = usr.BirthDate,
                Bloodgroup = usr.Bloodgroup,
                CheckupData = usr.CheckupData,
                City = usr.City,
                State = usr.State,
                Email = usr.Email,
                Name = usr.Name,
                Mobile = usr.Mobile,
                Gender = usr.Gender,
                Height = usr.Height,
                Weight = usr.Weight,
            };
            return View(rc);
        }

        [HttpGet]
        [Authorize(Roles = "Citizen")]
        //remaining
        public async Task<IActionResult> CitizenMadeCheckup()
        {
            ApplicationUser usr = await GetCurrentUserAsync();

            var citizenMadeCheckup = new CitizenMadeCheckup()
            {
                ID = usr.Id,
                Height = usr.Height,
                Weight = usr.Weight,
                Bloodgroup = usr.Bloodgroup,
                CheckupData = usr.CheckupData,
            };
            return View(citizenMadeCheckup);
        }

        [HttpPost]
        [Authorize(Roles = "Citizen")]
        public async Task<IActionResult> CitizenMadeCheckup(CitizenMadeCheckup citizenMadeCheckup)
        {
            var checkuped_user = userManager.Users.Where(usr => usr.Id == citizenMadeCheckup.ID).FirstOrDefault();
            checkuped_user.Bloodgroup = citizenMadeCheckup.Bloodgroup;
            checkuped_user.Height = citizenMadeCheckup.Height;
            checkuped_user.Weight = citizenMadeCheckup.Weight;
            checkuped_user.CheckupData = citizenMadeCheckup.CheckupData;

            IdentityResult task = await userManager.UpdateAsync(checkuped_user);

            TempData["SuccessMessage"] = "Profile Updated Successfully!";
            return RedirectToAction("Dashboard", "Citizen");
        }

        public IEnumerable<CitizenHospital> test()
        {
            IEnumerable<CitizenHospital> citizenHospitals = context.CitizenHospitals;
            return citizenHospitals;
        }


        [HttpGet]
        [Authorize(Roles = "Citizen")]
        public async Task<IActionResult> RequestPatientConfirm()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            ApplicationUser usr_hospital = userManager.Users.Where(u => u.Id == usr.hid).FirstOrDefault();
            RegisterHospital rh = new RegisterHospital()
            {
                Address = usr_hospital.Address,
                City = usr_hospital.City,
                State = usr_hospital.State,
                Name = usr_hospital.Name,
                OwnerName = usr_hospital.OwnerName,
                Email = usr_hospital.Email,
                Mobile = usr_hospital.Mobile,
                Telephone = usr_hospital.Telephone,
                MaxBeds = (int)usr_hospital.MaxBeds,
            };

            var i = patientRepository.GetAllPatients();
            var patients_of_hospitals_count = (context.Patients.Where(pat => pat.Hospital.Id == usr.hid).Count());
            var requested_patients_of_hospital = (context.RequestPatients.Where(rp => rp.hospitalId == usr_hospital.HospitalId).Count());
            ViewBag.beds = patients_of_hospitals_count + requested_patients_of_hospital;
            return View(rh);
        }

        [HttpGet]
        [Authorize(Roles ="Citizen")]
        public async Task<IActionResult> RequestPatient()
        {
            
            ApplicationUser usr = await GetCurrentUserAsync();
            ApplicationUser usr_hospital = userManager.Users.Where(u => u.Id == usr.hid).FirstOrDefault();
            var patient = patientRepository.GetAllPatients().Where(patients => patients.CitizenId == usr.CitizenId).FirstOrDefault();
            if(patient==null)
            {
                var req_usr = context.RequestPatients.Where(rp => rp.citizenId == usr.CitizenId).FirstOrDefault();
                if (req_usr == null)
                {
                    var patients_of_hospitals_count = (context.Patients.Where(pat => pat.Hospital.Id == usr.hid).Count());
                    var requested_patients_of_hospital = (context.RequestPatients.Where(rp => rp.hospitalId == usr_hospital.HospitalId).Count());

                    if ((patients_of_hospitals_count+requested_patients_of_hospital) >= usr_hospital.MaxBeds)
                    {
                        //add error
                        //max beds limit reached
                        TempData["ErrorMessage"] = "Sorry !! All Beds are full in the Hospital!";
                        return RedirectToAction("Dashboard", "Citizen");
                    }

                    RequestPatient rp = new RequestPatient();
                    var max_rp_id = context.RequestPatients.Max(user => user.Id);
                    rp.Id = max_rp_id + 1 ;
                    rp.citizenId = usr.CitizenId;
                    rp.hospitalId = usr_hospital.HospitalId;

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.RequestPatients ON;");
                        context.RequestPatients.Add(rp);
                        context.SaveChanges();
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.RequestPatients OFF;");
                        transaction.Commit();
                    }

                    TempData["SuccessMessage"] = "Request made Succcessfully for Hospitalization!";
                    return RedirectToAction("Dashboard", "Citizen");
                }
                else
                {
                    //add error
                    TempData["ErrorMessage"] = "You are already requested for Hospitalization!";
                    return RedirectToAction("Dashboard", "Citizen");
                }
            }
            else
            {
                //add error
                TempData["ErrorMessage"] = "You are already a Patient and already Hospitalized!";
                return RedirectToAction("Dashboard", "Citizen");
            }
        }

        [HttpGet]
        [Authorize(Roles ="Citizen")]
        public IActionResult DeleteRequestPatientConfirm()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Citizen")]
        public async Task<IActionResult> DeleteRequestPatient()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var all_patients = patientRepository.GetAllPatients().Where(patients => patients.CitizenId == usr.CitizenId).FirstOrDefault();
            if (all_patients == null)
            {
                if (context.RequestPatients.Where(rp => rp.citizenId == usr.CitizenId).FirstOrDefault() == null)
                {
                    // add error
                    //not requested yet
                    TempData["ErrorMessage"] = "You haven't yet requested for Hospitalization!";
                    return RedirectToAction("Dashboard", "Citizen");
                }
                else
                {
                    var req_patient = context.RequestPatients.Where(us => us.citizenId == usr.CitizenId).FirstOrDefault();
                    context.RequestPatients.Remove(req_patient);
                    context.SaveChanges();

                    TempData["SuccessMessage"] = "Request discarded Succcessfully for Hospitalization!";
                    return RedirectToAction("Dashboard", "Citizen");
                }
            }
            else
            {
                //add error
                //already patient
                TempData["ErrorMessage"] = "You are already a Patient and already Hospitalized!";
                return RedirectToAction("Dashboard", "Citizen");
            }
        }
    }
}
