using System.Collections.Generic;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.Contracts.Interfaces
{
    public interface IAuthorManager
    {
        List<AuthorDto> GetAuthors();
        AuthorDto GetAuthor(int authorId);
        void UpdateAuthor(AuthorDto author);
        void InsertAuthor(AuthorDto newAuthor);
        void DeleteAuthor(int authorId);
    }
}
