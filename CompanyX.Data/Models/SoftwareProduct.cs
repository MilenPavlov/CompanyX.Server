using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CompanyX.Data.Models
{
    public class SoftwareProduct
    {
        [Key]
        public int SoftwareProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Version { get; set; }

        public string ShortDescription  { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
