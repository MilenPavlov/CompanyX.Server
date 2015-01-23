using System.ComponentModel.DataAnnotations;

namespace CompanyX.Data.Models
{
    public class Nationality
    {
        [Key]
        public int NationalityId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
