using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyX.Data.Interfaces;
using CompanyX.Data.Models;
using CompanyX.Data.Services;

namespace CompanyX.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(IUnitOfWork unit):base(unit)
        {
            
        }
    }
}
