using CompanyX.Data.Models;
using CompanyX.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyX.Interfaces
{
    public interface IEntityFactory
    {
        EmployeeViewModel CreateEmployee(Employee employee);
    }
}
