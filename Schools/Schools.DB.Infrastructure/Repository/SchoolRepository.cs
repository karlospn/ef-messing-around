using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schools.DB.Infrastructure.Context;

namespace Schools.DB.Infrastructure.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolDBEntities _context;

        public SchoolRepository(SchoolDBEntities context)
        {
            _context = context;
        }

        public List<Student> GetStudents()
        {
            return _context.Students
                .Include("StudentAddress")
                .Include("Courses")
                .Include("Standard")
                .OrderBy( _ => _.StudentID)
                .AsNoTracking()
                .ToList();
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            return _context.Students.ToListAsync();
        }

    }
}
