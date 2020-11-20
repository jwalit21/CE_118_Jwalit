using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aarogyam.Models;
using Aarogyam.Models.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Aarogyam.Controllers
{
    public class AdvisoryController : Controller
    {
        private readonly IAdvisoryRepository advisoryRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext context;

        public AdvisoryController(IAdvisoryRepository advisoryRepository,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext context)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.advisoryRepository = advisoryRepository;
        }

        [HttpGet]
        [Authorize(Roles ="Goverment")]
        public IActionResult Index()
        {
            var SuccessMessage = TempData["SuccessMessage"];
            if(SuccessMessage != null)
            {
                ViewBag.SuccessMessage = SuccessMessage;
            }
            var ErrorMessage = TempData["ErrorMessage"];
            if (ErrorMessage != null)
            {
                ViewBag.ErrorMessage = ErrorMessage;
            }

            return View(advisoryRepository.GetAllAdvisorys());
        }

        [HttpGet]
        [Authorize(Roles ="Hospital, Citizen")]
        public IActionResult AdvisoryList()
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

            return View(advisoryRepository.GetAllAdvisorys());
        }


        [HttpGet]
        [Authorize(Roles = "Goverment")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Goverment")]
        public IActionResult Create(Advisory advisory)
        {
            if (ModelState.IsValid)
            {
                Advisory newAdvisory = advisoryRepository.Add(advisory);
                TempData["SuccessMessage"] = "Advisory Published Successfully!";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Goverment")]
        public IActionResult Edit(int id)
        {
            Advisory advisory  = advisoryRepository.GetAdvisory(id);
            if (advisory == null)
            {
                TempData["ErrorMessage"] = "Advisory not found!";
                return RedirectToAction("Index","Advisory");
            }
            else
            {
                return View(advisory);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Goverment")]
        public IActionResult Edit(Advisory advisory)
        {
            Advisory changed_advisory = advisoryRepository.Update(advisory);

            TempData["SuccessMessage"] = "Advisory Updated Successfully!";
            return RedirectToAction("Index", "Advisory");
        }

        [HttpGet]
        [Authorize(Roles = "Goverment")]
        public IActionResult Delete(int id)
        {
            Advisory advisory = advisoryRepository.GetAdvisory(id);
            if (advisory == null)
            {
                TempData["ErrorMessage"] = "Advisory not found!";
                return RedirectToAction("Index", "Advisory");
            }
            return View(advisory);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Goverment")]
        public IActionResult DeleteConfirmed(int id)
        {
            Advisory advisory = advisoryRepository.GetAdvisory(id);
            advisoryRepository.Delete(advisory.AdvisoryId);

            TempData["SuccessMessage"] = "Advisory Deleted Successfully!";
            return RedirectToAction("Index", "Advisory");
        }


        [HttpGet]
        [Authorize]
        public IActionResult Details(int id)
        {   
            Advisory advisory = advisoryRepository.GetAdvisory(id);
            var userid = signInManager.UserManager.GetUserId(User);
            var user = context.Users.Where(usr => usr.Id == userid).FirstOrDefault();
         
            if (advisory == null)
            {
                TempData["ErrorMessage"] = "Advisory not found!";
                if (user.IsGoverment)
                    return RedirectToAction("Index", "Advisory");
                return RedirectToAction("AdvisoryList", "Advisory");
            }
            else
            {
                if (user.IsGoverment)
                    return View(advisory);

                return View("AdvisoryDetails",advisory);
            }
        }
    }
}
