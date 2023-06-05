using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventOAPI.Tables
{
    [Table("OwnerTable")]
    public class OwnerTable
    {
        [Key]
        public int OwnerId { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string OwnerEmail { get; set; } = string.Empty;
        public string OwnerPhone { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^.*(?=.{6,})(?=.*[a-zA-Z])(?=.*\\d)(?=.*[!&$%&? \"]).*$")]
        public string OwnerPassword { get; set; } = string.Empty;

        public ImageTable  OwnerPic { get; set; }
    }

}
