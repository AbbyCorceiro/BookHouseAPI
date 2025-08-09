using DataLayer.Models;
using DataLayer.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookHouseDBContext _context;
        public BookController(BookHouseDBContext context) 
        { 
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll() 
        {
            return await _context.Books.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Book>>> GetById(int id) 
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null) return NotFound("The book doesn´t exist");
            return Ok(book);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Book>> PostBook(Book book) 
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { Id = book.Id}, book);
        }

        [HttpPut("modify")]
        public async Task<ActionResult<Book>> PutBook(int id, Book book) 
        {
            if (book is null) return NotFound();
            if (book.Id != id) return BadRequest();
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(book);  
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Book>> DeleteBook(int id) 
        {
            var book = await _context.Books.FindAsync(id);
            if (book is not null) _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok("Book deleted");
        }
    }
}
