using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Books.Entities;

namespace Books.Web.DataContext
{
    public class BookContext : DbContext
    {
        public BookContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}