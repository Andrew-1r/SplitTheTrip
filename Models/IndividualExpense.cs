using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplitTheTrip.Models
{
    [Table("individual_expense")]
    public class IndividualExpense
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TotalExpense")]
        public int TotalExpenseId { get; set; }
        public required TotalExpense TotalExpense { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public required GroupMember Member { get; set; }

        [ForeignKey("Payer")]
        public int PayerId { get; set; }
        public required GroupMember Payer { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        public required string SplitType { get; set; } // "percent" or "flat"

        [Column(TypeName = "decimal(10,2)")]
        public decimal SplitValue { get; set; }
    }
}
