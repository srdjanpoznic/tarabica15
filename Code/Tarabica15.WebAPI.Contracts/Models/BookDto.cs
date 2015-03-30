using Tarabica15.WebAPI.Contracts.ModelsDb;

namespace Tarabica15.WebAPI.Contracts.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? NumberOfPages { get; set; }
        public int? PublishedYear { get; set; }
        public AuthorDto Author { get; set; }
        public LibraryDto Library { get; set; }

        public static implicit operator BookDto(Book source)
        {
            BookDto target = null;

            if (source != null)
            {
                target = new BookDto
                {
                    Id = source.Id,
                    Title = source.Title,
                    NumberOfPages = source.NumberOfPages,
                    PublishedYear = source.PublishedYear,
                    Author = source.Author,
                    Library = source.Library
                };
            }

            return target;
        }
    }
}