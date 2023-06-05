using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventOAPI.Tables
{
    [Table("SpaceTable")]
    public class SpaceTable
    {
        [Key]
        public int SapaceId { get; set; }
        public string   SpaceName { get; set; } = string.Empty;
        [Required]
        public string SpaceLocation { get; set; } = string.Empty;
        [Required]
        
        public OwnerTable Owner { get; set; }
        
        public UserTable Creator { get; set; }

        public List<ImageTable> SpaceImages { get; set; }
    }
}
