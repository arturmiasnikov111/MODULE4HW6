using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MODULE4HW6.Models;

namespace MODULE4HW6.ModelsConfiguration
{
    public class ArtistsToSongConfiguration : IEntityTypeConfiguration<ArtistsToSong>
    {
        public void Configure(EntityTypeBuilder<ArtistsToSong> builder)
        {
            builder.ToTable("ArtistsToSong").HasKey(i => new { i.ArtistId, i.SongId });
            builder.Property(i => i.ArtistId).HasColumnName("ArtistId");
            builder.Property(i => i.SongId).HasColumnName("SongId");

            builder.HasOne(p => p.Artist)
                .WithMany(d => d.ArtistsToSongs)
                .HasForeignKey(p => p.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Song)
                .WithMany(d => d.ArtistsToSongs)
                .HasForeignKey(p => p.SongId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new ArtistsToSong { ArtistId = 1, SongId = 2 },
                new ArtistsToSong { ArtistId = 2, SongId = 1 },
                new ArtistsToSong { ArtistId = 3, SongId = 4 },
                new ArtistsToSong { ArtistId = 4, SongId = 5 },
                new ArtistsToSong { ArtistId = 1, SongId = 3 });
        }
    }
}