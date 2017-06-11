using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schools.DB.Infrastructure.Context;

namespace Schools.DB.Infrastructure.Repository
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly SchoolDBEntities _context;

        public TeachersRepository(SchoolDBEntities context )
        {
            _context = context;
            //_context.Database.Log = x => Debug.WriteLine(x) ;
        }


        public void AddTeacher()
        {
            var teacher = new Teacher
            {
                TeacherName = "Josh",
                TeacherType = TeacherType.Guest
            };
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }
    }
}
