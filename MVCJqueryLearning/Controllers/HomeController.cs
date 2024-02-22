using Microsoft.AspNetCore.Mvc;
using MVCJqueryLearning.Data;
using MVCJqueryLearning.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVCJqueryLearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public JsonResult GetStudent()
        {
            var std = _db.Students.FirstOrDefault();

            if (std != null)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(std);
                return Json(json);
            }

            return Json(null);
        }

        public JsonResult Search()
        {
            return Json(new List<string> { "Tomato", "Potato" });
        }

        [HttpPost]
        public JsonResult AddStudent(Student student)
        {
            Student std = new Student { Name = student.Name, Email = student.Email };
            _db.Students.Add(std);
            _db.SaveChanges();
            return Json("true");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}