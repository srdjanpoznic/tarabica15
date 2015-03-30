using System.Data.Entity;
using Tarabica15.WebAPI.Contracts.ModelsDb;
using Tarabica15.WebAPI.Data.Models.Mapping;

namespace Tarabica15.WebAPI.Data.Models
{
    public partial class Tarabica15Context : DbContext
    {
        static Tarabica15Context()
        {
            Database.SetInitializer<Tarabica15Context>(null);
        }

        public Tarabica15Context()
            : base("Name=Tarabica15Context")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new LibraryMap());
        }
    }
}
