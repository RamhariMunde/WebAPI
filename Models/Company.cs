using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace CreateWebAPI.Models
{
    public class Company
    {
        [Key]
        public string CompanyCode { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyAddress { get; set; }

        [Required]
        public string CompanyGSTN { get; set; }

        [Required]
        public string CompanyUserId { get; set; }

        [Required]
        public string CompanyStatus { get; set; }

        [Required]
        public DateTime CompanyStartdate { get; set; }

        [Required]
        public string CompanyNatureofWork { get; set; }
    }
}
