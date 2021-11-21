using System;
using Microsoft.EntityFrameworkCore;
using MODULE4HW6.Models;
using MODULE4HW6.ModelsConfiguration;

namespace MODULE4HW6
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Genre> Genres { get; set; }
        
        public DbSet<ArtistsToSong> ArtistsToSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistsToSongConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder configureBuilder)
        {
            configureBuilder.LogTo(Console.Write);
        }
    }
}