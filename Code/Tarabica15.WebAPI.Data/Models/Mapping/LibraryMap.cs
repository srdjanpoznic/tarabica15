using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tarabica15.WebAPI.Contracts.ModelsDb;

namespace Tarabica15.WebAPI.Data.Models.Mapping
{
    public class LibraryMap : EntityTypeConfiguration<Library> 
    {
        public LibraryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Library");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Country).HasColumnName("Country");
        }
    }
}
