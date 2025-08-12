using DataLayer.Context;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookHouseDBContext _context;

        public BookRepository(BookHouseDBContext context)
        {
            _context = context;
        }

        // GET all books
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        // GET book by id
        public async Task<Book?> GetById(int id)
        {
            if (id <= 0) 
                return null;

            return await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        // POST new book
        public async Task<Book> PostBook(Book book)
        {
            if (book == null) 
                throw new ArgumentNullException(nameof(book));

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        // PUT update book
        public async Task<Book?> PutBook(int id, Book book)
        {
            if (book == null || id != book.Id) 
                return null;

            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook == null) 
                return null;

            _context.Entry(existingBook).CurrentValues.SetValues(book);
            await _context.SaveChangesAsync();
            return existingBook;
        }

        // DELETE book
        public async Task<Book?> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null) 
                return null;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}