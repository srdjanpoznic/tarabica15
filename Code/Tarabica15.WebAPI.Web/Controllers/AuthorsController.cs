using System.Collections.Generic;
using System.Web.Http;
using Tarabica15.WebAPI.Contracts.Interfaces;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.Web.Controllers
{
    public class AuthorsController : ApiController
    {
        private readonly IAuthorManager _authorManager;

        public AuthorsController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        [HttpGet]
        public IEnumerable<AuthorDto> GetAuthors()
        {
            return _authorManager.GetAuthors();
        }

        public AuthorDto GetAuthor(int id)
        {
            var author = _authorManager.GetAuthor(id);

            if (author == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            return author;
        }

        [HttpPost]
        public IHttpActionResult PostAuthor(AuthorDto author)
        {
            if (author == null)
            {
                return BadRequest("Argument Null");
            }

            var authorExists = _authorManager.GetAuthor(author.Id);

            if (authorExists != null)
            {
                return BadRequest("Exists");
            }

            _authorManager.InsertAuthor(author);
            return Ok();
        }

        [HttpPut]
        [HttpPatch]
        public IHttpActionResult PutAuthor(AuthorDto author)
        {
            if (author == null)
            {
                return BadRequest("Argument Null");
            }

            var authorExists = _authorManager.GetAuthor(author.Id);

            if (authorExists == null)
            {
                return NotFound();
            }

            _authorManager.UpdateAuthor(author);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var author = _authorManager.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            _authorManager.DeleteAuthor(id);
            return Ok();
        }

        //TODO
        //[Route("api/authors/{authorId}/books")]
        //public IEnumerable<BookDto> GetBooksByAuthor(int authorId)
        //{
        //    return _bookManager.GetBooks().Where(b => b.Author.Id == authorId);
        //}
    }
}
