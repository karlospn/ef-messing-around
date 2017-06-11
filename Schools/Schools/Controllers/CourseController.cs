using System.Web.Mvc;
using Schools.DB.Infrastructure.Repository;

namespace Schools.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICoursesRepository _coursesRepository;

        public CourseController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public ActionResult Index()
        {
            var courses = _coursesRepository.GetCoursesByStudentId(2);
            return View(courses);
        }

    }
}