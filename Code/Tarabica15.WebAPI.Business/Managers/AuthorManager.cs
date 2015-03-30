using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tarabica15.WebAPI.Common.Logging;
using Tarabica15.WebAPI.Contracts.Interfaces;
using Tarabica15.WebAPI.Contracts.Models;
using Tarabica15.WebAPI.Contracts.ModelsDb;
using Tarabica15.WebAPI.Data.Models;

namespace Tarabica15.WebAPI.Business.Managers
{
    public class AuthorManager : BaseManager, IAuthorManager
    {
        private readonly Tarabica15Context _context;

        public AuthorManager(ILogger logger, Tarabica15Context context)
            : base(logger)
        {
            _context = context;
        }

        public List<AuthorDto> GetAuthors()
        {
            var books = _context.Books.ToList();
            var authors = _context.Authors.ToList().Select(author => (AuthorDto)author).ToList();

            foreach (var author in authors)
            {
                author.Books = books.Where(b => b.AuthorId == author.Id).Select(b => (BookDto) b).ToList();
            }

            return authors;
        }

        public AuthorDto GetAuthor(int authorId)
        {
            AuthorDto author = _context.Authors.SingleOrDefault(a => a.Id == authorId);

            var books = _context.Books.ToList();

            if (author != null)
            {
                author.Books = books.Where(b => b.AuthorId == author.Id).Select(b => (BookDto)b).ToList();
            }

            return author;
        }

        public void UpdateAuthor(AuthorDto author)
        {
            Author aut = _context.Authors.SingleOrDefault(a => a.Id == author.Id);

            if (aut != null)
            {
                aut.FirstName = author.FirstName;
                aut.LastName = author.LastName;
                aut.City = author.City;
                aut.Country = author.Country;

                _context.Entry(aut).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void InsertAuthor(AuthorDto newAuthor)
        {
            Author author = new Author
            {
                Id = newAuthor.Id,
                City = newAuthor.City,
                Country = newAuthor.Country,
                FirstName = newAuthor.FirstName,
                LastName = newAuthor.LastName,
            };

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int authorId)
        {
            Author author = _context.Authors.Find(authorId);

            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}