using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyX.Data.Models;
using CompanyX.Data.ViewModels;
using CompanyX.Data.Interface;

namespace CompanyX.Data.Factory
{
    public class EntityFactory : IEntityFactory
    {
        public EmployeeViewModel CreateEmployee(Employee employee)
        {
            return new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                Company = employee.Company.Name,
                DateOfBirth = employee.DateOfBitrh,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Nationality = employee.Nationality.Name,
                NINumber = employee.NINumber,
                Salary = employee.Salary
            };
        }

        public List<EmployeeViewModel> CreateEmployees(List<Employee> employees)
        {
            var employeeViewModels = employees.Select(CreateEmployee).ToList();

            return employeeViewModels;
        }
    }
}
