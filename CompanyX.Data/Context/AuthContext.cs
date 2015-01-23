using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyX.Data.Helpers;
using CompanyX.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CompanyX.Data.Context
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext(): base("AuthContext")
        {
            //Database.SetInitializer<AuthContext>(new AuthInitializer());
        }
        //public DbSet<User> Users { get; set; }
    }
}
