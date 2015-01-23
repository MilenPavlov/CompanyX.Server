using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyX.Data.Context;
using CompanyX.Data.Models;

namespace CompanyX.Data.Helpers
{
    public class CompanyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            var Nationalities = new List<Nationality>
            {
                new Nationality {Name = "British", NationalityId = 1},
                new Nationality {Name = "Bulgarian", NationalityId = 2},
                new Nationality {Name = "Scottish", NationalityId = 3}
            };
            context.Nationalities.AddRange(Nationalities);
            context.SaveChanges();

            var company = new Company { Name = "Company X", Address = "1 My Way", CompanyId = 1};
            context.Company.Add(company);
            context.SaveChanges();

          

            var employee = new Employee
            {
                FirstName = "Employee",
                LastName = "X",
                NINumber = "abc",
                DateOfBitrh = DateTime.Parse("1990-05-01"),
                Salary = 1000m,
                CompanyId = 1,
                NationalityId = 1
            };

            context.Employees.Add(employee);
            context.SaveChanges();

            var softwareProduct = new SoftwareProduct {Name = "product 1", ShortDescription = "Does stuff", Version = 1.0m, Price = 100m, CompanyId = 1};

            context.SoftwareProducts.Add(softwareProduct);

           
        }
    }
}
