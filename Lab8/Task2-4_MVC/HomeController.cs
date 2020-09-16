using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab8_Task4_BasicMVC.Models;

namespace Lab8_Task4_BasicMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test1()
        {
            int num1 = 56,num2 = 8;
            int sum = num1 + num2;
            ViewBag.num1 = num1.ToString();
            ViewBag.num2 = num2.ToString();
            ViewBag.sum = sum.ToString();
            return View();
        }

        [HttpGet]
        public IActionResult Test2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test2(string num1,string num2)
        {
            string sum = (int.Parse(num2) + int.Parse(num1)).ToString();
            ViewBag.num1 = num1;
            ViewBag.num2 = num2;
            ViewBag.sum = sum;
            return View() ;
        }

        [HttpGet]
        public IActionResult User_Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult User_Registration(string num1, string num2)
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
