using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Aarogyam.Models;
using Aarogyam.Models.IRepositories;
using Aarogyam.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Aarogyam.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IHospitalRepositoy _hospitalRepository;
        private readonly ICitizenRepository _citizenRepository;
        private readonly AppDbContext context;

        public AccountController(

            IHospitalRepositoy hospitalRepositoy,
            ICitizenRepository citizenRepository,
            AppDbContext context,
            UserManager<ApplicationUser> userManager,
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(forgotPasswordViewModel.Email);
                if(user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account" , 
                        new { email = forgotPasswordViewModel.Email, token = token }, Request.Scheme);



                    System.Net.ServicePointManager.Expect100Continue = false;
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("jwalitshah2q@gmail.com");
                        mail.To.Add(forgotPasswordViewModel.Email);
                        mail.Subject = "Aarogyam Reset  Password Link";
                        mail.Body = "<h3>Please Reset Password by clicking <a href=\""+passwordResetLink+"\"> This Link </a>.</h3><br>" + passwordResetLink;
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("jwalitshah2q@gmail.com", "Sonal@123");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }

                    TempData["SuccessMessage"] = "User Found";
                    return View("ForgotPasswordConfirmation");
                }
                //user is not registered

                TempData["ErrorMessage"] = "User not found with the provided EmailID.";
                return View("ForgotPasswordConfirmation");
            }
            return View(forgotPasswordViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token,string email)
        {
            if(token == null || email==null)
            {
                ModelState.AddModelError("", "Invalid Password Reset Token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(resetPasswordViewModel.Email);
                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.Password);
                    if(result.Succeeded)
                    {
                        TempData["SuccessMessage"] = "Password is reseted.";
                        return View("ResetPasswordConfirmation");
                    }
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(resetPasswordViewModel);
                }

                TempData["ErrorMessage"] = "User not found with the provided EmailID.";
                return View("ResetPasswordConfirmation");
            }
            return View(resetPasswordViewModel);
        }

        [HttpGet]
        public IActionResult RegisterHospital()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterHospital(RegisterHospital registerHospital)
        {

            ApplicationUser Hospital_with_max_ID = _hospitalRepository.GetMaxHospital();
            if (ModelState.IsValid)
            {
                //copy data from registerviewmodel to identityuser
                var user = new ApplicationUser
                {
                    HospitalId = Hospital_with_max_ID.HospitalId + 1,
                    UserName = registerHospital.Email,
                    Email = registerHospital.Email,
                    Name = registerHospital.Name,
                    OwnerName = registerHospital.OwnerName,
                    Mobile = registerHospital.Mobile,
                    Telephone = registerHospital.Telephone,
                    IsHospital = true,
                    DateOfJoin = DateTime.Now,
                    State = registerHospital.State,
                    City = registerHospital.City,
                    Address = registerHospital.Address,
                    MaxBeds = registerHospital.MaxBeds
                };

                var result = await userManager.CreateAsync(user, registerHospital.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user,"Hospital");
                    //await userManager.AddToRoleAsync(user, "Hospital");
                    //await signInManager.SignInAsync(user, isPersistent: false);

                    TempData["SuccessMessage"] = "Hospital Registered successfully!";
                    return RedirectToAction("HospitalList", "Goverment");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerHospital);
        }

        [HttpGet]
        [Authorize(Roles = "Citizen")]
        public IActionResult UpdateCitizen()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            var hospitals = userManager.Users.Where(user => user.IsHospital == true);
            foreach (var item in hospitals)
            {
                selectListItems.Add(new SelectListItem { Text = item.Name, Value = item.HospitalId.ToString() });
            }
            ViewBag.hospitals = selectListItems;

            var logged_user_id = signInManager.UserManager.GetUserId(User);
            var logged_user_citizen = userManager.Users
                .Where(usr => usr.Id == logged_user_id)
                .FirstOrDefault();
            var rc = new RegisterCitizen()
            {
                Id = 0, //logged_user_citizen.CitizenId,
                Name = logged_user_citizen.Name,
                Email = logged_user_citizen.Email,
                BirthDate = logged_user_citizen.BirthDate,
                Bloodgroup = logged_user_citizen.Bloodgroup,
                Height = logged_user_citizen.Height,
                Weight = logged_user_citizen.Weight,
                Gender = logged_user_citizen.Gender,
                City = logged_user_citizen.City,
                State = logged_user_citizen.State,
                Address = logged_user_citizen.Address,
                Mobile = logged_user_citizen.Mobile,
                CheckupData = logged_user_citizen.CheckupData,
                Hospital_id_select = context.CitizenHospitals
                    .Where(us => us.CitizenId == logged_user_citizen.CitizenId)
                    .FirstOrDefault()
                    .Hospital.HospitalId,
            };

            //Here only it comes
            var y = context.CitizenHospitals;

            return View(rc);
        }

        //public int test()
        //{
        //    var logged_user_id = signInManager.UserManager.GetUserId(User);
        //    var logged_user_citizen = userManager.Users
        //        .Where(usr => usr.Id == logged_user_id)
        //        .FirstOrDefault();
        //    var Hospital_id_select = context.CitizenHospitals
        //            .Where(us => us.CitizenId == logged_user_citizen.CitizenId)
        //            .FirstOrDefault()
        //            .Hospital.HospitalId;
        //    IEnumerable<CitizenHospital> citizenHospitals = context.CitizenHospitals;
        //    var i = 9;
        //    return Hospital_id_select;
        //    //return citizenHospitals;
        //}

        public void test()
        {
            IEnumerable<CitizenHospital> ch = _hospitalRepository.GetCitizens();
            Response.Redirect("~/Account/UpdateCitizen");
        }

        [HttpPost]
        [Authorize(Roles ="Citizen")]
        public IActionResult UpdateCitizen(RegisterCitizen registerCitizen)
        {
            var logged_user_id = signInManager.UserManager.GetUserId(User);
            var logged_user_citizen = userManager.Users
                .Where(usr => usr.Id == logged_user_id)
                .FirstOrDefault();

            var user = userManager.Users.Where(u => u.Id == logged_user_id).FirstOrDefault();
            user.Name = registerCitizen.Name;
            user.BirthDate = registerCitizen.BirthDate;
            user.Address = registerCitizen.Address;
            user.City = registerCitizen.City;
            user.State = registerCitizen.State;
            user.Height = registerCitizen.Height;
            user.Weight = registerCitizen.Weight;
            user.Gender = registerCitizen.Gender;
            user.CheckupData = registerCitizen.CheckupData;
            user.Bloodgroup = registerCitizen.Bloodgroup;
            user.Mobile = registerCitizen.Mobile;
            user.hid = userManager.Users.Where(us => us.HospitalId == registerCitizen.Hospital_id_select).FirstOrDefault().Id;

            CitizenHospital ch = new CitizenHospital()
            {
                CitizenId = logged_user_citizen.CitizenId,
                Hospital = userManager.Users.Where(us => us.HospitalId == registerCitizen.Hospital_id_select).FirstOrDefault(),
            };

            var ch_changes = context.CitizenHospitals.Attach(ch);
            ch_changes.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            _citizenRepository.Update(user);
            TempData["SuccessMessage"] = "Profile Updated Successfully.";
            return RedirectToAction("Dashboard", "Citizen");
        }

        [HttpGet]
        public IActionResult RegisterCitizen()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            var hospitals = userManager.Users.Where(user => user.IsHospital == true);
            foreach (var item in hospitals)
            {
                selectListItems.Add(new SelectListItem { Text = item.Name, Value = item.HospitalId.ToString() });
            }
            ViewBag.hospitals = selectListItems;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCitizen(RegisterCitizen registerCitizen)
        {
            ApplicationUser Citizen_with_max_ID = _citizenRepository.GetMaxCitizen();
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
                    BirthDate = registerCitizen.BirthDate,
                    Bloodgroup = registerCitizen.Bloodgroup,
                    Height = registerCitizen.Height,
                    Weight = registerCitizen.Weight,
                    CheckupData = registerCitizen.CheckupData,
                    State = registerCitizen.State,
                    City = registerCitizen.City,
                    Address = registerCitizen.Address,
                    hid = userManager.Users.Where(us => us.HospitalId == registerCitizen.Hospital_id_select).FirstOrDefault().Id,
                };

                CitizenHospital citizenHospital = new CitizenHospital();

                citizenHospital.Hospital = userManager.Users
                    .Where(user => user.IsHospital == true)
                    .Where(us => us.HospitalId == registerCitizen.Hospital_id_select)
                    .FirstOrDefault();

                citizenHospital.CitizenId = Citizen_with_max_ID.CitizenId + 1;
                Console.WriteLine(citizenHospital.CitizenId);

                using( var transaction = context.Database.BeginTransaction())
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
                    await signInManager.SignInAsync(user, isPersistent: false);

                    TempData["SuccessMessage"] = "Citizen Registered & Logged Successfully";
                    return RedirectToAction("Dashboard", "Citizen");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerCitizen);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "Welcome " + model.Email + "!";

                        if (model.role == "hospital")
                        {
                            return RedirectToAction("Dashboard", "Hospital");
                        }
                        else if (model.role == "goverment")
                        {
                            return RedirectToAction("Dashboard", "Goverment");
                        }
                        else if(model.role == "citizen")
                        {
                            return RedirectToAction("Dashboard", "Citizen");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                await signInManager.SignOutAsync();
            }
            return View(model);
        }

        [Route("Account/Login/{role}")]
        [HttpGet]
        public IActionResult Login(string role)
        {
            if(role=="hospital" || role=="citizen" || role=="goverment")
                ViewBag.role = role;
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            TempData["SuccessMessage"] = "Logged out Successfully!";
            return RedirectToAction("Index", "Home");
        }
    }
}
