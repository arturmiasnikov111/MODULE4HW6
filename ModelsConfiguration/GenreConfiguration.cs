using MODULE4HW6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MODULE4HW6.ModelsConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(i => i.GenreId);
            builder.Property(i => i.GenreId).HasColumnName("GenreId").IsRequired();
            builder.Property(i => i.Title).HasColumnName("Title").IsRequired();

            builder.HasData(
                new Genre { GenreId = 1, Title = "Rock" },
                new Genre { GenreId = 2, Title = "Rap" },
                new Genre { GenreId = 3, Title = "Trance" },
                new Genre { GenreId = 4, Title = "Techno" },
                new Genre { GenreId = 5, Title = "Pop" });
        }
    }
}