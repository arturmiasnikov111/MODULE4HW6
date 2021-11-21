using System;
using System.Collections.Generic;

namespace MODULE4HW6.Models
{
    public class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public string Duration { get; set; }

        public DateTime ReleasedDate { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public List<ArtistsToSong> ArtistsToSongs { get; set; }
    }
}