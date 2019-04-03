using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Api.Models;
using Fisher.Bookstore.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Api;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreContext db;

        public BooksController(BookstoreContext db)
        {
            this.db = db;
           
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Books);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
            if (book == null || book.Id != id)
            {
                return BadRequest();
            }

            var bookToEdit = db.Books.FirstOrDefault(b => b.Id == id);
            if (bookToEdit == null)
            {
                return NotFound();
            }

            bookToEdit.Title = book.Title;
            bookToEdit.ISBN = book.ISBN;

            db.Books.Update(bookToEdit);
            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return NoContent();
        }
    }
}