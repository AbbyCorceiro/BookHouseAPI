using DataLayer.Models;

namespace BusinessLayer.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task<Book> PostBook(Book book);
        Task<Book> PutBook(int id, Book book);
        Task<Book?> DeleteBook(int id);
    }
}