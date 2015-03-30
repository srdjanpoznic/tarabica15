using System.Collections.Generic;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.Contracts.Interfaces
{
    public interface IBookManager
    {
        List<BookDto> GetBooks();
        BookDto GetBook(int bookId);
        void UpdateBook(BookDto book);
        void InsertBook(BookDto newBook);
        void DeleteBook(int bookId);
    }
}
