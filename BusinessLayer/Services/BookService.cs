using DataLayer.Models;
using DataLayer.Repository;

namespace BusinessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository repo)
        {
            _bookRepository = repo;
        }

        // GET all books
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        // GET book by id
        public async Task<Book?> GetById(int id)
        {
            if (id <= 0) 
                return null;

            return await _bookRepository.GetById(id);
        }

        // POST new book
        public async Task<Book> PostBook(Book book)
        {
            if (book == null) 
                throw new ArgumentNullException(nameof(book));

            return await _bookRepository.PostBook(book);
        }

        // PUT update book
        public async Task<Book?> PutBook(int id, Book book)
        {
            if (book == null || id != book.Id) 
                return null;

            return await _bookRepository.PutBook(id, book);
        }

        // DELETE book
        public async Task<Book?> DeleteBook(int id)
        {
            if (id <= 0) 
                return null;

            return await _bookRepository.DeleteBook(id);
        }
    }
}
