using System;
using System.Collections.Generic;

namespace MODULE4HW6.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string InstagramUrl { get; set; }

        public List<ArtistsToSong> ArtistsToSongs { get; set; }
    }
}