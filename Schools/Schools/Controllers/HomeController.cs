using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Schools.DB.Infrastructure.Repository;

namespace Schools.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISchoolRepository _schoolRepository;

        public HomeController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<ActionResult> Index()
        {
            //var students = _schoolRepository.GetStudents();
            var students = await _schoolRepository.GetStudentsAsync();
            return View(students);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}