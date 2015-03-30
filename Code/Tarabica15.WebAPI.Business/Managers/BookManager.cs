using System.Collections.Generic;
using System.Linq;
using Tarabica15.WebAPI.Common.Logging;
using Tarabica15.WebAPI.Contracts.Interfaces;
using Tarabica15.WebAPI.Contracts.Models;
using Tarabica15.WebAPI.Data.Models;

namespace Tarabica15.WebAPI.Business.Managers
{
    public class BookManager : BaseManager, IBookManager
    {
        private readonly Tarabica15Context _context;

        public BookManager(ILogger logger, Tarabica15Context context)
            : base(logger)
        {
            _context = context;
        }

        public List<BookDto> GetBooks()
        {
            return _context.Books.ToList().Select(book => (BookDto)book).ToList();
        }

        public BookDto GetBook(int bookId)
        {
            BookDto book = _context.Books.SingleOrDefault(b => b.Id == bookId);
            return book;
        }

        public void UpdateBook(BookDto book)
        {
            throw new System.NotImplementedException();
        }

        public void InsertBook(BookDto newBook)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBook(int bookId)
        {
            throw new System.NotImplementedException();
        }
    }
}