using System.Web.Mvc;
using Schools.DB.Infrastructure.Repository;

namespace Schools.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeacherController(ITeachersRepository teachersRepository )
        {
            _teachersRepository = teachersRepository;
        }

        public void Index()
        {
            _teachersRepository.AddTeacher();           
        }

    }
}