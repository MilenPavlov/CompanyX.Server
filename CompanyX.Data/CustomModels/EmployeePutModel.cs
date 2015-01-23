using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyX.Data.Models;

namespace CompanyX.Data.CustomModels
{
    public class EmployeePutModel
    {
        public int Id { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }
}
