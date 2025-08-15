using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplitTheTrip.Models
{
    [Table("group")]
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string PinHash { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public required User Owner { get; set; } // navigation property

        [Required, MaxLength(255)]
        public required string Name { get; set; }
    }
}