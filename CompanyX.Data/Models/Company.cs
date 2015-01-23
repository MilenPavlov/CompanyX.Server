using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyX.Data.Models
{
    public class Company
    {

        public Company()
        {
            Employees = new List<Employee>();
            SoftwareProducts = new List<SoftwareProduct>();
        }
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<SoftwareProduct> SoftwareProducts { get; set; }
    }
}
