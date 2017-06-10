using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schools.DB.Infrastructure.Context;

namespace Schools.DB.Infrastructure.Repository
{
    public class SchoolRepositoryUsing : ISchoolRepository
    {
        public List<Student> GetStudents()
        {
            using (var context = new SchoolDBEntities())
            {
                return context.Students
              .Include("StudentAddress")
              .Include("Courses")
              .Include("Standard")
              .OrderBy(_ => _.StudentID)
              .AsNoTracking()
              .ToList();
            }
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            using (var context = new SchoolDBEntities())
            {
                return context.Students.ToListAsync();
            }
        }

        public void AddStudentAsync(Student student)
        {
            using (var context = new SchoolDBEntities())
            {
                context.Students.Add(student);
                LogEntitiesState(context);
                context.SaveChanges();
            }
        }

        public void UpdateStudentAsync(Student student)
        {
            using (var context = new SchoolDBEntities())
            {
                context.Students.AddOrUpdate(student);
                LogEntitiesState(context);
                context.SaveChanges();
            }
        }

        private void LogEntitiesState(SchoolDBEntities context)
        {
            foreach (var entity in context.ChangeTracker.Entries())
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
