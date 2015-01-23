using System;
using System.Collections.Generic;
using CompanyX.Data.Models;

namespace CompanyX.Data.Interfaces
{
    public interface IEmployeesRepository : IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int EmployeeId);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(int EmployeeId);
        void UpdateEmployee(Employee student);
        void Save();
    }
}
