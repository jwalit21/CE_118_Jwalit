using System;
using System.Collections.Generic;
using System.Linq;
using Aarogyam.Models;
using Aarogyam.Models.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aarogyam.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository taskRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppDbContext context;
        private readonly IHospitalRepositoy hospitalRepositoy;

        public TaskController(ITaskRepository taskRepository,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            AppDbContext context,
            IHospitalRepositoy hospitalRepositoy)
        {
            this.userManager = userManager;
            this.hospitalRepositoy = hospitalRepositoy;
            this.signInManager = signInManager;
            this.context = context;
            this.taskRepository = taskRepository;
        }

        [HttpGet]
        [Authorize(Roles ="Goverment")]
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

            return View(taskRepository.GetAllTasks().Where(task => task.Finished == false));
        }

        [HttpGet]
        [Authorize(Roles = "Goverment")]
        public IActionResult FinishedListGoverment()
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

            return View(taskRepository.GetAllTasks().Where(task => task.Finished == true));
        }

        [HttpGet]
        [Authorize(Roles = "Hospital")]
        public IActionResult FinishedListHospital()
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

            var userid = signInManager.UserManager.GetUserId(User);
            var user = context.Users.Where(usr => usr.Id == userid).FirstOrDefault();

            var tasks = context.Tasks
                .Where(task => task.Hospital.HospitalId == user.HospitalId)
                .Where(t => t.Finished == true);
            return View(tasks);
        }


        [HttpGet]
        [Authorize(Roles ="Hospital")]
        public IActionResult TaskList()
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

            var userid = signInManager.UserManager.GetUserId(User);
            var user = context.Users.Where(usr => usr.Id == userid).FirstOrDefault();

            var tasks = context.Tasks
                .Where(task => task.Hospital.HospitalId == user.HospitalId)
                .Where(t=> t.Finished == false);
            return View(tasks);
        }

        [HttpGet]
        [Authorize(Roles ="Goverment")]
        public IActionResult Create()
        {
            var hospitals = hospitalRepositoy.GetAllHospitals();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in hospitals)
                selectListItems.Add(new SelectListItem { Text = item.Name + " " + item.Email, Value = item.HospitalId.ToString() });

            ViewBag.hospital_list = selectListItems;
            return View();

        }

        [HttpPost]
        [Authorize(Roles = "Goverment")]
        public IActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                task.Hospital = context.Users
                    .Where(hp => hp.HospitalId == Int32.Parse(task.Hospital.Id))
                    .FirstOrDefault();
                Task newTask = taskRepository.Add(task);
                var t = newTask.Hospital.Id;
                TempData["SuccessMessage"] = "Task Created & Assigned Successfully!";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Goverment")]
        public IActionResult Edit(int id)
        {
            Task task = taskRepository.GetTask(id);
            if (task == null)
            {
                TempData["ErrorMessage"] = "Task not found!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(task);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Goverment")]
        public IActionResult Edit(Task task)
        {
            Task changed_task = taskRepository.Update(task);

            TempData["SuccessMessage"] = "Task Updated Successfully!";
            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        [Authorize(Roles ="Goverment")]
        public IActionResult Delete(int id)
        {
            Task task = taskRepository.GetTask(id);
            if (task == null)
            {
                TempData["ErrorMessage"] = "Task not found!";
                return RedirectToAction("Index");
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Goverment")]
        public IActionResult DeleteConfirmed(int id)
        {
            Task task = taskRepository.GetTask(id);
            taskRepository.Delete(task.TaskId);

            TempData["SuccessMessage"] = "Task Deleted Successfully!";
            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        [Authorize(Roles ="Goverment, Hospital")]
        public IActionResult Details(int id)
        {
            //dummy record for checking
            //Student s = new Student { StudentID = Student_ID, cpi = 92, email = "hhh@h.com", mobile = "9998889998", Name = "j", Subjects = null };
            var userid = signInManager.UserManager.GetUserId(User);
            var user = context.Users.Where(usr => usr.Id == userid).FirstOrDefault();

            Task task = taskRepository.GetTask(id);
            if (task == null)
            {
                TempData["ErrorMessage"]= "Task not found!";
                if(user.IsGoverment)
                    return RedirectToAction("Index");
                return RedirectToAction("TaskList");
            }
            else
            {
                return View(task);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Goverment, Hospital")]
        public IActionResult FinishedTaskDetails(int id)
        {
            var userid = signInManager.UserManager.GetUserId(User);
            var user = context.Users.Where(usr => usr.Id == userid).FirstOrDefault();

            Task task = taskRepository.GetTask(id);
            if (task == null)
            {
                TempData["ErrorMessage"] = "Task not found!";
                if (user.IsGoverment)
                    return RedirectToAction("FinishedListGoverment");
                return RedirectToAction("FinishedListHospital");
            }
            else
            {
                return View(task);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Hospital")]
        public IActionResult MarkDone(int id)
        {
            var userid = signInManager.UserManager.GetUserId(User);
            var user = context.Users.Where(usr => usr.Id == userid).FirstOrDefault();

            Task task = taskRepository.GetTask(id);
            if (task == null)
            {
                TempData["ErrorMessage"] = "Task not found!";
                return RedirectToAction("TaskList","Task");
            }
            return View(task);
        }

        [HttpPost, ActionName("MarkDone")]
        [Authorize(Roles = "Hospital")]
        public IActionResult MarkDoneConfirmed(int id)
        {
            Task task = taskRepository.GetTask(id);
            task.DateOfFinished = DateTime.Now;
            task.Finished = true;
            Task taskChanged = taskRepository.Update(task);

            TempData["SuccessMessage"] = "Task Marked Done Successfully!";
            return RedirectToAction("TaskList", "Task");
        }

    }
}
