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

namespace Aarogyam.Controllers
{
    [Authorize(Roles ="Goverment")]
    public class GovermentController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IHospitalRepositoy _hospitalRepository;
        private readonly ICitizenRepository _citizenRepository;
        private readonly AppDbContext context;

        public GovermentController(
            UserManager<ApplicationUser> userManager,
            IHospitalRepositoy hospitalRepositoy,
            ICitizenRepository citizenRepository,
            AppDbContext context,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._hospitalRepository = hospitalRepositoy;
            this._citizenRepository = citizenRepository;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Goverment")]
        [HttpGet]
        public IActionResult HospitalList()
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

            var Hospitals =  context.Users.Where(c => c.IsHospital == true).ToList();
            List<RegisterHospital> rh = new List<RegisterHospital>();
            foreach (var usr_hospital in Hospitals)
            {
                var usr = new RegisterHospital()
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
                    Id = usr_hospital.HospitalId,
                };
                var u = usr.Id;
                rh.Add(usr);
            }
            return View(rh);
        }

        [HttpGet]
        [Authorize(Roles ="Goverment")]
        public IActionResult HospitalDetails(int id)
        {
            var usr_hospital = userManager.Users.Where(c => c.HospitalId == id).FirstOrDefault();
            if (usr_hospital == null)
            {
                TempData["ErrorMessage"] = "Hospital not found!";
                return RedirectToAction("Dashboard", "Goverment");
            }

            var usr = new RegisterHospital()
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

            return View(usr);
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
            if (signInManager.IsSignedIn(User) && usr.IsGoverment==true)
            {
                ViewBag.total_hospitals = context.Users.Where(c => c.IsHospital == true).Count();
                ViewBag.total_pending_tasks = context.Tasks.Where(c => c.Finished == false).Count();
                ViewBag.total_advisories = context.Advisories.Count();
                ViewBag.citizens = context.Users.Where(c => c.IsCitizen == true).Count();
                var cd = context.CovidDatas.Where(c => (c.Date.Day == DateTime.Now.Day && c.Date.Month == DateTime.Now.Month && c.Date.Year == DateTime.Now.Year))
                    .FirstOrDefault();
                if (cd == null)
                    ViewBag.is_provided = false;
                else
                    ViewBag.is_provided = true;

                return View();
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
