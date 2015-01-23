using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyX.Data.Context;
using CompanyX.Data.Models;
using CompanyX.Data.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CompanyX.Data.Helpers
{
    public class AuthInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AuthContext>
    {
        protected override void Seed(AuthContext context)
        {
            var user = new User
            {
                UserName = "webapi",
                
                Password = "rocks"
            };
            var repo = new AuthRepository();
            context.Users.Add(user);
        }
    }
}
