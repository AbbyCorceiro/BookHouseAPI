using DataLayer.Models;

namespace DataLayer.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task<Book> PostBook(Book book);
        Task<Book?> PutBook(int id, Book book);
        Task<Book?> DeleteBook(int id);
    }
}