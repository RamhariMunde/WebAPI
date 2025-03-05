using System.ComponentModel.DataAnnotations;

namespace CreateWebAPI.Models
{
    public class UserModel
    {
        [Key] // Primary Key
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
