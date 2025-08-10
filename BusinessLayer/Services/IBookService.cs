using DataLayer.Models;

namespace BusinessLayer.Services
{
    public interface IBookService
    {
        //GET
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(int id);

        //POST
        Task<Book> PostBook(Book book);

        //PUT
        Task<Book> PutBook(int id, Book book);

        //DELETE
        Task<Book?> DeleteBook(int id);
    }
}
