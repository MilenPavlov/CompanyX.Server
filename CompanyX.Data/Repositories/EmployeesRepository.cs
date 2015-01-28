using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByID(int EmployeeId)
        {
            return await _context.Employees.FindAsync(EmployeeId);
        }

        public void InsertEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public async Task DeleteEmployee(int EmployeeId)
        {
            var employee = await _context.Employees.FindAsync(EmployeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
