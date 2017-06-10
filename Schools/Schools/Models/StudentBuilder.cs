using System;
using Schools.DB.Infrastructure.Context;

namespace Schools.Models
{
    public static class StudentBuilder
    {
        public static Student CreateStudent(bool hasStandard, bool hasCourses, bool hasAddress, int randomLength)
        {
            return Build(null, hasStandard, hasCourses, hasAddress, randomLength);
        }

        public static Student EditStudent(int id, bool hasStandard, bool hasCourses, bool hasAddress, int randomLength)
        {
            return Build(id, hasStandard, hasCourses, hasAddress, randomLength);
        }


        private static Student Build(int? studentId, bool hasStandard, bool hasCourses, bool hasAddress, int randomLength)
        {
            Student newStudent = new Student()
            {
                StudentName = RandomString(randomLength)
            };

            if (studentId != null)
            {
                newStudent.StudentID = (int) studentId;
            }

            if (hasStandard)
            {
                newStudent.Standard = new Standard()
                {
                    StandardName = RandomString(randomLength)
                };
            }

            if (hasCourses)
            {
                newStudent.Courses.Add(new Course()
                {

                    CourseName = RandomString(randomLength),
                    Teacher = new Teacher()
                    {
                        TeacherName = RandomString(randomLength)
                    }
                });
            }

            if (hasAddress)
            {
                newStudent.StudentAddress = new StudentAddress()
                {
                    Address1 = RandomString(randomLength),
                    City = RandomString(randomLength),
                    State = RandomString(randomLength),
                    Student = newStudent,
                    
                };
            }
            return newStudent;
        }

        private static string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(stringChars);
        }
    }
}