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
    public class RequestPatientController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IPatientRepository patientRepository;

        public RequestPatientController(AppDbContext context,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);


        [HttpGet]
        [Authorize(Roles = "Hospital")]
        public async Task<IActionResult> Index()
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

            ApplicationUser usr = await GetCurrentUserAsync();

            var rp = context.RequestPatients.Where(rp => rp.hospitalId == usr.HospitalId).ToList();
            List<RequestPatientView> requestPatientLists = new List<RequestPatientView>();

            foreach (var item in rp)
            {
                var citizen = userManager.Users.Where(us => us.CitizenId == item.citizenId).FirstOrDefault();
                requestPatientLists.Add(new RequestPatientView()
                {
                    citizenId = item.citizenId,
                    Email = citizen.Email,
                    Mobile = citizen.Mobile,
                    Name = citizen.Name,
                    Id = item.Id,
                });
            }
            return View(requestPatientLists);
        }

        [HttpGet]
        [Authorize(Roles = "Hospital")]
        public async Task<IActionResult> Accept(int id)
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var requested_usr = context.RequestPatients.Find(id);

            if (usr.HospitalId != requested_usr.hospitalId)
            {
                //add error 
                //403 access denied
                TempData["ErrorMessage"] = "Access Denied!";
                return RedirectToAction("Index", "RequestPatient");
            }

            var max_patient = patientRepository.GetMaxPatient();

            Patient patient = new Patient();
            patient.PatientId = max_patient.PatientId + 1;
            patient.CitizenId = requested_usr.citizenId;
            patient.Hospital = userManager.Users
                                .Where(user => user.IsHospital == true)
                                .Where(us => us.HospitalId == usr.HospitalId)
                                .FirstOrDefault();

            using (var transaction = context.Database.BeginTransaction())
            {
                context.Patients.Add(patient);
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Patients ON;");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Patients OFF;");
                transaction.Commit();
            }

            var deleted_req_user = context.RequestPatients.Remove(requested_usr);
            context.SaveChanges();

            TempData["SuccessMessage"] = "Citizen Hospitalized Successfully!";
            return RedirectToAction("Index", "RequestPatient");
        }

        [HttpGet]
        [Authorize(Roles = "Hospital")]
        public async Task<IActionResult> Discard(int id)
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var requested_usr = context.RequestPatients.Find(id);

            if (usr.HospitalId != requested_usr.hospitalId)
            {
                //add error 
                //403 access denied
                TempData["ErrorMessage"] = "Access Denied!";
                return RedirectToAction("Index", "RequestPatient");
            }

            context.RequestPatients.Remove(requested_usr);
            context.SaveChanges();

            TempData["SuccessMessage"] = "Citizen's Hospital Request Discarded Successfully!";
            return RedirectToAction("Index", "RequestPatient");
        }
    }
}
