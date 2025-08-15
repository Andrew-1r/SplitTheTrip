using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplitTheTrip.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public required string Username { get; set; }

        [Required, EmailAddress, MaxLength(255)]
        public required string Email { get; set; }

        [Required]
        public required string PasswordHash { get; set; } // Use ASP.NET Identity instead
    }
}
