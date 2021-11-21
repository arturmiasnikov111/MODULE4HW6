using System.Collections.Generic;

namespace MODULE4HW6.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string Title { get; set; }

        public List<Song> SongList { get; set; }
    }
}