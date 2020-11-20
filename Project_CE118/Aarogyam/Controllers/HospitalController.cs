using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aarogyam.Models;
using Aarogyam.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Aarogyam.Controllers
{
    [Authorize(Roles ="Hospital")]
    public class HospitalController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext context;

        public HospitalController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            AppDbContext context)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            RegisterHospital rh = new RegisterHospital()
            {
                Address = usr.Address,
                MaxBeds = (int)usr.MaxBeds,
                OwnerName = usr.OwnerName,
                City = usr.City,
                State = usr.State,
                Email = usr.Email,
                Name = usr.Name,
                Mobile = usr.Mobile,
                Telephone = usr.Telephone,
            };
            ViewBag.doj = usr.DateOfJoin;
            return View(rh);
        }

        public async Task<IActionResult> Dashboard()
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
            if (signInManager.IsSignedIn(User) && usr.IsHospital == true)
            {
                var due_taks = context.Tasks.Where(t => (
                    t.Finished == false && 
                    t.Hospital.Id == usr.Id && 
                    (t.DateOfDue.Day >= DateTime.Now.Day || t.DateOfDue.Month >= DateTime.Now.Month || t.DateOfDue.Year >= DateTime.Now.Year))).Count();
                ViewBag.due_task = due_taks;
                
                ViewBag.pending_task = context.Tasks.Where(t => (
                    t.Finished == false &&
                    t.Hospital.Id == usr.Id)).Count();
                
                ViewBag.finished_task = context.Tasks.Where(t => (
                    t.Finished == true &&
                    t.Hospital.Id == usr.Id)).Count();
                
                var patients_of_hospitals_count = (context.Patients.Where(pat => pat.Hospital.Id == usr.hid).Count());
                var requested_patients_of_hospital = (context.RequestPatients.Where(rp => rp.hospitalId == usr.HospitalId).Count());
                var total_occ_beds = requested_patients_of_hospital + patients_of_hospitals_count;
                ViewBag.beds = total_occ_beds;
                
                if (total_occ_beds >= usr.MaxBeds)
                    ViewBag.is_full = true;
                else
                    ViewBag.is_full = false;
                
                ViewBag.actual_beds = usr.MaxBeds;

                return View();
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
