using System.Collections.Generic;
using System.Web.Http;
using Tarabica15.WebAPI.Contracts.Interfaces;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.Web.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookManager _bookManager;

        public BooksController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            return _bookManager.GetBooks();
        }

        [HttpGet]
        public BookDto GetBook(int id)
        {
            return _bookManager.GetBook(id);
        }


        [HttpPost]
        public IHttpActionResult Post(BookDto book)
        {
            if (book == null)
            {
                return BadRequest("Argument Null");
            }

            var bookExists = _bookManager.GetBook(book.Id);

            if (bookExists!= null)
            {
                return BadRequest("Exists");
            }

            _bookManager.InsertBook(book);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(BookDto book)
        {
            if (book == null)
            {
                return BadRequest("Argument Null");
            }

            var bookExists = _bookManager.GetBook(book.Id);

            if (bookExists == null)
            {
                return NotFound();
            }

            _bookManager.UpdateBook(book);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var book = _bookManager.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookManager.DeleteBook(id);
            return Ok();
        }
    }
}
