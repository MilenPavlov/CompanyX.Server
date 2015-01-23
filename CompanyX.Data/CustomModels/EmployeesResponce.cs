using System.Collections.Generic;

namespace CompanyX.Data.CustomModels
{
    public  class EmployeesResponce : ResponseBase
    {
        public List<EmployeeViewModel> Employees { get; set; }
    }
}
