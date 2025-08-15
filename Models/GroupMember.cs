using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplitTheTrip.Models
{
    [Table("group_member")]
    public class GroupMember
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public required Group Group { get; set; }

        public bool IsOwner { get; set; }

        [Required, MaxLength(255)]
        public required string Name { get; set; }
    }
}