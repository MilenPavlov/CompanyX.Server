using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyX.Data.CustomModels
{
    public  class EmployeesResponce : ResponseBase
    {
        public List<EmployeeViewModel> Employees { get; set; }
    }
}
