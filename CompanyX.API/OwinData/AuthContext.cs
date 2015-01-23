using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CompanyX.API.OwinData
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
    }
}