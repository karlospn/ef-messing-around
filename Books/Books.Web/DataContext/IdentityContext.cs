using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Books.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Books.Web.DataContext
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static IdentityContext Create()
        {
            return new IdentityContext();
        }


    }
}