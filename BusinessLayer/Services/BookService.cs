using DataLayer.Models;
using DataLayer.Repository;

namespace BusinessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository repo) => _bookRepository = repo;

        //GET
        public async Task<IEnumerable<Book>> GetAll() => await _bookRepository.GetAll();
        public async Task<Book?> GetById(int id) => await _bookRepository.GetById(id);

        //POST
        public async Task<Book> PostBook(Book book) => await _bookRepository.PostBook(book);

        //PUT
        public async Task<Book?> PutBook(int id, Book book) => await _bookRepository.PutBook(id, book);

        //DELETE
        public async Task DeleteBook(int id) => await _bookRepository.DeleteBook(id);
    }
}
