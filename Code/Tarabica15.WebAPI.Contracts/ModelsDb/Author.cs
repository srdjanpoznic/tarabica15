using System;
using System.Collections.Generic;

namespace Tarabica15.WebAPI.Contracts.ModelsDb
{
    public partial class Author
    {
        public Author()
        {
            this.Books = new List<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
