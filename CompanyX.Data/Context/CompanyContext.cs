using System.Data.Entity;
using CompanyX.Data.Helpers;
using CompanyX.Data.Models;

namespace CompanyX.Data.Context
{
    public class CompanyContext : DbContext, IDbContext
    {
        public CompanyContext() :base("CompanyContext")
        {           
            Database.SetInitializer<CompanyContext>(new CompanyInitializer());
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<SoftwareProduct> SoftwareProducts { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
    }
}
