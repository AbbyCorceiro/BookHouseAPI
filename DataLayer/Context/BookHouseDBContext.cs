using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class BookHouseDBContext : DbContext
    {
        public BookHouseDBContext(DbContextOptions<BookHouseDBContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
