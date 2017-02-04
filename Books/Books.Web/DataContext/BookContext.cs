using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Books.Entities;

namespace Books.Web.DataContext
{
    public class BookContext : DbContext
    {
        public BookContext() : base("DefaultConnection")
        {
            Database.Log = sql => Debug.WriteLine(sql);
        }
        public DbSet<Book> Books { get; set; }
    }
}