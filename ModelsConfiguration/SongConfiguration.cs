using System;
using MODULE4HW6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MODULE4HW6.ModelsConfiguration
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(i => i.SongId);
            builder.Property(i => i.SongId).HasColumnName("SongId").IsRequired();
            builder.Property(i => i.Title).HasColumnName("Title").IsRequired();
            builder.Property(i => i.Duration).HasColumnName("Duration").IsRequired();

            builder.HasOne(i => i.Genre)
                .WithMany(i => i.SongList)
                .HasForeignKey(i => i.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Song { SongId = 1, Title = "Song#1", ReleasedDate = new DateTime(2020, 1, 1), Duration = "4m.56s", GenreId = 1 },
                new Song { SongId = 2, Title = "Song#2", ReleasedDate = new DateTime(2019, 12, 12), Duration = "5m.56s", GenreId = 2 },
                new Song { SongId = 3, Title = "Song#3", ReleasedDate = new DateTime(2018, 11, 11),  Duration = "2m.16s", GenreId = 3 },
                new Song { SongId = 4, Title = "Song#4", ReleasedDate = new DateTime(2017, 2, 2),  Duration = "4m.56s",  GenreId = 4 },
                new Song { SongId = 5, Title = "Song#5", ReleasedDate = new DateTime(2015, 7, 4),  Duration = "2m.16s", GenreId = 2 });
        }
    }
}
