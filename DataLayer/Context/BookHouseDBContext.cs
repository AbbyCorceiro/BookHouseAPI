using Microsoft.EntityFrameworkCore;
using Models;

namespace DataLayer.Context
{
    public class BookHouseDBContext : DbContext
    {
        public BookHouseDBContext(DbContextOptions<BookHouseDBContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
