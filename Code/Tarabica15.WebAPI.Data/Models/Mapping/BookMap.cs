using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tarabica15.WebAPI.Contracts.ModelsDb;

namespace Tarabica15.WebAPI.Data.Models.Mapping
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Books");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.PublishedYear).HasColumnName("PublishedYear");
            this.Property(t => t.NumberOfPages).HasColumnName("NumberOfPages");
            this.Property(t => t.AuthorId).HasColumnName("AuthorId");
            this.Property(t => t.LibraryId).HasColumnName("LibraryId");

            // Relationships
            this.HasOptional(t => t.Author)
                .WithMany(t => t.Books)
                .HasForeignKey(d => d.AuthorId);
            this.HasRequired(t => t.Library)
                .WithMany(t => t.Books)
                .HasForeignKey(d => d.LibraryId);

        }
    }
}
