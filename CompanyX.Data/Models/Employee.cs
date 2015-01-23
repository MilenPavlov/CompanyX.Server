using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyX.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBitrh { get; set; }
        [Required]
        public string NINumber  { get; set; }
        [Required]
        public decimal  Salary { get; set; }

        public int CompanyId { get; set; }

        public int NationalityId { get; set; }

        public virtual Company Company { get; set; }

        public virtual Nationality Nationality { get; set; }
    }
}
