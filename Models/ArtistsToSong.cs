namespace MODULE4HW6.Models
{
    public class ArtistsToSong
    {
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public int SongId { get; set; }

        public Song Song { get; set; }
    }
}