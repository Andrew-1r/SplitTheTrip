using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplitTheTrip.Models
{
    [Table("total_expense")]
    public class TotalExpense
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public required Group Group { get; set; }

        [ForeignKey("Payer")]
        public int PayerId { get; set; }
        public required GroupMember Payer { get; set; }

        [Required, MaxLength(255)]
        public required string Name { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
    }
}
