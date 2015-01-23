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
