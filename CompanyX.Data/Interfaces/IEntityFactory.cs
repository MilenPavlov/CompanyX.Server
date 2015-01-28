using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyX.Data.CustomModels;
using CompanyX.Data.Models;

namespace CompanyX.Data.Interfaces
{
    public interface IEntityFactory
    {
        EmployeeViewModel CreateEmployee(Employee employee);

        Task<IEnumerable<EmployeeViewModel>> CreateEmployees(IEnumerable<Employee> employees);

        Employee CreateBaseEmployee(EmployeeViewModel employeeViewModel);

        Employee CreateBaseEmployeePut(EmployeePutModel employeePutModel);
    }
}