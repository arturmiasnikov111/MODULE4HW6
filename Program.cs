using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using MODULE4HW6.Models;

namespace MODULE4HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = @"/Users/arturmiasnykov/RiderProjects/MODULE4HW6/MODULE4HW6/Configuration/configuration.json";
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile(root).Build();
            var dbOptionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            dbOptionBuilder.UseSqlServer(connectionString);

            var applicationContext = new ApplicationContext(dbOptionBuilder.Options);
            // 1 query

            var query =
                from artists in applicationContext.Artists
                join artistsToSong in applicationContext.ArtistsToSongs
                    on artists.ArtistId equals artistsToSong.ArtistId into artistsToSong

                from artoToSong in artistsToSong
                join songs in applicationContext.Songs
                    on artoToSong.SongId equals songs.SongId into artAndSongs

                from songAndGenres in artAndSongs
                join genre in applicationContext.Genres
                    on songAndGenres.GenreId equals genre.GenreId
                where songAndGenres.GenreId != null

                select new
                {
                    SongTitle = songAndGenres.Title,
                    ArtistName = artists.Name,
                    Genre = genre.Title,
                };
            query.ToList();

            //2 query
            var songCountByGenre = applicationContext.Songs
                .GroupBy(x => x.Genre.Title)
                .Select(x => new
                {
                    Title = x.Key,
                    Count = x.Count()
                }).ToList();

            //3 query
            var theYoungestArtist = applicationContext.Artists
                .OrderByDescending(x => x.DateOfBirth)
                .First();
            var writtenSongs = applicationContext.Songs
                .Where(x => x.ReleasedDate < theYoungestArtist.DateOfBirth)
                .ToList();
        }
    }
}