using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyX.Data.Context;
using CompanyX.Data.Interfaces;
using System.Transactions;
using CompanyX.Data.Models;
using CompanyX.Data.Repositories;

namespace CompanyX.Data.Services
{
    public class UnitOfWork: IUnitOfWork
    {
        //private TransactionScope _transaction;
        private CompanyContext _context= new CompanyContext();
        private GenericRepository<Employee> employeeRepository;
        private GenericRepository<SoftwareProduct> softwareRepository;
        private GenericRepository<Nationality> nationalityRepository; 

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new GenericRepository<Employee>(_context);                 
                }
                return employeeRepository;
            }

        }

        public GenericRepository<SoftwareProduct> SoftwareRepository
        {
            get
            {

                if (softwareRepository == null)
                {
                    softwareRepository = new GenericRepository<SoftwareProduct>(_context);
                }
                return softwareRepository;
            }
        }

        public GenericRepository<Nationality> NationalityRepository
        {
            get
            {
                if (nationalityRepository == null)
                {
                    nationalityRepository = new GenericRepository<Nationality>(_context);
                }
                return nationalityRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

      
    }
}
