using DataLayer.Context;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookHouseDBContext _context;
        public BookRepository(BookHouseDBContext context) => _context = context;

        //GET
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book;
        }

        //POST
        public async Task<Book> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        //PUT
        public async Task<Book> PutBook(int id, Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return book;
        }

        //DELETE
        public async Task<Book?> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is not null) _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
