using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventOAPI.Tables
{
    [Table("ChatTable")]
    public class ChatTable
    {
        [Key]
        public int ChatId { get; set; }
        [Required]
        public string Message { get; set; }

        public int ChatType { get; set; } = 0;

        public UserTable User { get; set; }

        public EventTable Event { get; set; }

    }
}
