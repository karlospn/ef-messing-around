﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schools.DB.Infrastructure.Context;

namespace Schools.DB.Infrastructure.Repository
{
    public interface ISchoolRepository
    {
        List<Student> GetStudents();
        Task<List<Student>> GetStudentsAsync();
    }
}
