using System;

namespace CompanyX.Data.CustomModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string NINumber { get; set; }
        public decimal Salary { get; set; }

        public string Nationality { get; set; }
        public string Company { get; set; }

        public int CompanyId { get; set; }

        public int NationalityId { get; set; }
    }
}
