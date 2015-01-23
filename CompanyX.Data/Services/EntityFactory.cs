using System.Collections.Generic;
using System.Linq;
using CompanyX.Data.CustomModels;
using CompanyX.Data.Models;
using CompanyX.Data.Interfaces;

namespace CompanyX.Data.Services
{
    public class EntityFactory : IEntityFactory
    {
        private readonly IUnitOfWork _unit;
        public EntityFactory(IUnitOfWork unit)
        {
            _unit = unit;
        }
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
                Salary = employee.Salary,
                CompanyId = employee.CompanyId,
                NationalityId = employee.NationalityId
            };
        }

       
        public List<EmployeeViewModel> CreateEmployees(List<Employee> employees)
        {
            var employeeViewModels = employees.Select(CreateEmployee).ToList();

            return employeeViewModels;
        }


        public Employee CreateBaseEmployee(EmployeeViewModel employeeViewModel)
        {
            int natId = 1;
            var firstOrDefault = _unit.NationalityRepository.Get(x => x.Name == employeeViewModel.Nationality).FirstOrDefault();
            if (firstOrDefault != null)
            {
                natId = firstOrDefault.NationalityId;
            }

            var employee = new Employee
            {
                CompanyId = 1,
                DateOfBitrh = employeeViewModel.DateOfBirth,
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                NationalityId = natId,
                NINumber = employeeViewModel.NINumber,
                Salary = employeeViewModel.Salary
            };

            return employee;
        }

        public Employee CreateBaseEmployeePut(EmployeePutModel employeePutModel)
        {
            int natId = 1;
            var firstOrDefault = _unit.NationalityRepository.Get(x => x.Name == employeePutModel.Employee.Nationality).FirstOrDefault();
            if (firstOrDefault != null)
            {
                natId = firstOrDefault.NationalityId;
            }
            var employee = new Employee
            {
                EmployeeId = employeePutModel.Id,
                CompanyId = 1,
                DateOfBitrh = employeePutModel.Employee.DateOfBirth,
                FirstName = employeePutModel.Employee.FirstName,
                LastName = employeePutModel.Employee.LastName,
                NationalityId = natId,
                NINumber = employeePutModel.Employee.NINumber,
                Salary = employeePutModel.Employee.Salary
            };

            return employee;
            
        }
    }
}
