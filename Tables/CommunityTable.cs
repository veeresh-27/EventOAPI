using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventOAPI.Tables
{
    [Table("CommunityTable")]
    public class CommunityTable
    {
        [Key]
        public int CommunityId { get; set; }

        [Required]
        public string CommunityName { get; set;}
        [Required]
        public string CommunityDescription { get; set;} = string.Empty;
        [Required]
        public UserTable CommunityCreator { get; set;}

        public List<UserTable> Members { get; set; } = new List<UserTable>();

        public List<ImageTable> CommunityImages { get; set; }

    }
}
