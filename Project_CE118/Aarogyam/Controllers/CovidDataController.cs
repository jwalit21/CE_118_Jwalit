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
    public class CovidDataController : Controller
    {
        private ICovidDataRepository covidDataRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext context;

        public CovidDataController(ICovidDataRepository covidDataRepository,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext context)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.covidDataRepository = covidDataRepository;
        }

        [Authorize(Roles = "Goverment")]
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

            return View(covidDataRepository.GetAllCovidDatas());
        }

        [Authorize]
        public IActionResult CovidDataList()
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

            return View(covidDataRepository.GetAllCovidDatas());
        }

        [HttpGet]
        [Authorize(Roles ="Goverment")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Goverment")]
        public IActionResult Create(CovidData covidData)
        {
            if (ModelState.IsValid)
            {
                var covid_datas = covidDataRepository.GetAllCovidDatas();
                var matched = false;
                foreach (var item in covid_datas)
                {
                    if ((item.Date.Day == DateTime.Now.Day) && (item.Date.Month == DateTime.Now.Month) && (item.Date.Year == DateTime.Now.Year))
                        matched = true;
                }
                if(matched)
                {
                    //add error
                    //you hve covid data already for this day
                    TempData["ErrorMessage"] = "You have already Published today's Covid19 Data!";
                    return RedirectToAction("Index");
                }
                covidData.Date = DateTime.Now;
                CovidData newCovidData = covidDataRepository.Add(covidData);
                TempData["SuccessMessage"] = "Today's Covid19 Data published!";

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Goverment")]
        public IActionResult Edit(int id)
        {
            CovidData covidData = covidDataRepository.GetCovidData(id);
            if (covidData == null)
            {
                TempData["ErrorMessage"] = "Data not found!";
                return RedirectToAction("Index", "CovidData");
            }
            else
            {
                return View(covidData);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Goverment")]
        public IActionResult Edit(CovidData covidData)
        {
            CovidData changed_covidData = covidDataRepository.Update(covidData);
            TempData["SuccessMessage"] = "Data Updated Successfully!";
            return RedirectToAction("Index", "CovidData");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int id)
        {
            //dummy record for checking
            //Student s = new Student { StudentID = Student_ID, cpi = 92, email = "hhh@h.com", mobile = "9998889998", Name = "j", Subjects = null };

            CovidData covidData = covidDataRepository.GetCovidData(id);
            var userid = signInManager.UserManager.GetUserId(User);
            var user = context.Users.Where(usr => usr.Id == userid).FirstOrDefault();

            if (covidData == null)
            {
                TempData["ErrorMessage"] = "Data not found!";
                if (user.IsGoverment)
                    return RedirectToAction("Index", "CovidData");
                return RedirectToAction("CovidDataList", "CovidData");
            }
            else
            {
                if (user.IsGoverment)
                    return View(covidData);

                return View("CovidDataDetails",covidData);
            }
        }
    }
}
