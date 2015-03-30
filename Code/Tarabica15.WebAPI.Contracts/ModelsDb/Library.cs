using System;
using System.Collections.Generic;

namespace Tarabica15.WebAPI.Contracts.ModelsDb
{
    public partial class Library
    {
        public Library()
        {
            this.Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
