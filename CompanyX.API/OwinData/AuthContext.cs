using Microsoft.AspNet.Identity.EntityFramework;

namespace CompanyX.API.OwinData
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
    }
}