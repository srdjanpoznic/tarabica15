using System;

namespace Tarabica15.WebAPI.Contracts.ModelsDb
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> PublishedYear { get; set; }
        public Nullable<int> NumberOfPages { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public int LibraryId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Library Library { get; set; }
    }
}
