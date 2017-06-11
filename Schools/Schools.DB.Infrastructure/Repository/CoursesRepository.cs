using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schools.DB.Infrastructure.Context;

namespace Schools.DB.Infrastructure.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly SchoolDBEntities _context;

        public CoursesRepository(SchoolDBEntities context )
        {
            _context = context;
        }


        public List<string> GetCoursesByStudentId(int id)
        {
            var courses = _context.GetCoursesByStudentId(id);
            return courses.Select(course => course.coursename).ToList();
        }
    }
}
