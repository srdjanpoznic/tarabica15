using System;
using System.Collections.Generic;
using System.Linq;
using Tarabica15.WebAPI.Contracts.ModelsDb;

namespace Tarabica15.WebAPI.Contracts.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<BookDto> Books { get; set; }

        public static implicit operator AuthorDto(Author source)
        {
            AuthorDto target = null;

            if (source != null)
            {
                target = new AuthorDto
                {
                    Id = source.Id,
                    FirstName = source.FirstName,
                    LastName = source.LastName,
                    City = source.City,
                    Country = source.Country
                };
            }

            return target;
        }
    }
}