using CompanyX.Data.Models;
using CompanyX.Data.Repositories;

namespace CompanyX.Data.Services
{
    public interface IUnitOfWork
    {
        GenericRepository<Employee> EmployeeRepository { get; }
        GenericRepository<SoftwareProduct> SoftwareRepository { get; }

        GenericRepository<Nationality> NationalityRepository { get; }
        void Save();
        void Dispose(bool disposing);
        void Dispose();
    }
}