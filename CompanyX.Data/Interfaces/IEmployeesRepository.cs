using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyX.Data.Models;

namespace CompanyX.Data.Interfaces
{
    public interface IEmployeesRepository : IDisposable
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeByID(int EmployeeId);
        void InsertEmployee(Employee employee);
        Task DeleteEmployee(int EmployeeId);
        Task UpdateEmployeeAsync(Employee student);
        Task Save();
    }
}
