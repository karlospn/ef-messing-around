using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Schools.DB.Infrastructure.Context;
using Schools.DB.Infrastructure.Repository;
using Schools.Models;

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
            var students = await _schoolRepository.GetStudentsAsync();
            DeleteStudent();
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

        private void AddComposedStudent()
        {
            _schoolRepository.AddStudentAsync(StudentBuilder.CreateStudent(true, true, true, 10));
        }

        private void EditComposedStudent()
        {
            _schoolRepository.UpdateStudentAndDependenciesAsync(StudentBuilder.EditStudent(7, true, true, true, 8));
        }

        private void EditSimpleStudent()
        {
            _schoolRepository.UpdateStudentAsync(StudentBuilder.EditStudent(7, false, false, false, 8));
        }

        private void DeleteStudent()
        {
            _schoolRepository.DeleteStudentAsync(9);
        }
    }
}