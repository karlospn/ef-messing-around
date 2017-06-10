using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorThis.GraphDiff;
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

        public void AddStudentAsync(Student student)
        {
            try
            {
                _context.Students.Add(student);
                LogEntitiesState();
                _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }          
        }

        public void UpdateStudentAsync(Student student)
        {
            _context.UpdateGraph<Student>(student,
                map =>
                    map.OwnedEntity(x => x.StudentAddress).OwnedEntity(x => x.Standard).OwnedCollection(x => x.Courses));
            //var currentStudent = _context.Students.Local.FirstOrDefault(x => x.StudentID == student.StudentID);
            //if (currentStudent != null)
            //{
            //    _context.Entry(currentStudent).CurrentValues.SetValues(student);
            //}
            //else
            //{
            //    _context.Students.Add(student);
            //}

            _context.SaveChangesAsync();
        }


        private void LogEntitiesState()
        {
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                Debug.WriteLine($"Entity Name: {entity.Entity.GetType().FullName}");

                foreach (var property in entity.CurrentValues.PropertyNames)
                {
                    Debug.WriteLine($"Property Name: {property}  - Value: {entity.CurrentValues[property]}");
                }
                Debug.WriteLine($"Entity State: {entity.State}");
            }
        }

    }
}
