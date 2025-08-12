using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [Range(1000, 9999, ErrorMessage = "Year must be a valid 4-digit year.")]
        public int YearPublication { get; set; }

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Genre { get; set; }

        public bool Available { get; set; }
    }
}
