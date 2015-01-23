using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CompanyX.Data.Context;
using CompanyX.Data.Interfaces;
using CompanyX.Data.Models;

namespace CompanyX.Data.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly CompanyContext _context;
        private bool disposed = false;

        public EmployeesRepository(CompanyContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeByID(int EmployeeId)
        {
            return _context.Employees.Find(EmployeeId);
        }

        public void InsertEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void DeleteEmployee(int EmployeeId)
        {
            var employee = _context.Employees.Find(EmployeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
