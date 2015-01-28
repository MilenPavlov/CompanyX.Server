using System.Collections.Generic;

namespace CompanyX.Data.CustomModels
{
    public  class EmployeesResponce : ResponseBase
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}
