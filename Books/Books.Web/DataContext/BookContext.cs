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
        public DbSet<Book> Books { get; set; }

        public BookContext() : base("DefaultConnection")
        {
            Database.Log = sql => Debug.WriteLine(sql);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("library");
            base.OnModelCreating(modelBuilder);
        }
    }
}