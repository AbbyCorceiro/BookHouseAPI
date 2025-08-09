
namespace DataLayer.Models
{
    public class Book
    {
        public int Id { get; set; } 
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required int YearPublication { get; set; }
        public required string ISBN { get; set; }
        public string? Genre { get; set; }
        public bool Available { get; set; }
    }
}
