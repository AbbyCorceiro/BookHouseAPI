using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IBookRepository
    {
        //GET
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(int id);

        //POST
        Task<Book> PostBook(Book book);

        //PUT
        Task<Book?> PutBook(int id, Book book);

        //DELETE
        Task<Book?> DeleteBook(int id);
    }
}
