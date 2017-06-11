using System.Collections.Generic;

namespace Schools.DB.Infrastructure.Repository
{
    public interface ICoursesRepository
    {
        List<string> GetCoursesByStudentId(int id);
    }
}