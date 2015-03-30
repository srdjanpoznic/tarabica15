using System;
using System.Collections.Generic;
using System.Linq;
using Tarabica15.WebAPI.Contracts.ModelsDb;

namespace Tarabica15.WebAPI.Contracts.Models
{
    public class LibraryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<BookDto> Books { get; set; }

        public static implicit operator LibraryDto(Library source)
        {
            LibraryDto target = null;

            if (source != null)
            {
                target = new LibraryDto
                {
                    Id = source.Id,
                    Name = source.Name,
                    DateCreated = source.DateCreated,
                    Address = source.Address,
                    City = source.City,
                    Country = source.Country
                };
            }

            return target;
        }
    }
}