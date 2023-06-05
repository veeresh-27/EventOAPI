using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventOAPI.Tables
{
    [Table("ImageTable")]
    public class ImageTable
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string ImageLink { get; set; } = string.Empty;

    }
}
