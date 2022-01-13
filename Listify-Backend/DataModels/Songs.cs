namespace Listify_Backend.DataModels
{
    public class Songs
    {
        public int ID { get; set; }
        public string SongArtist { get; set; }
        public string SongTitle { get; set; }
        public Enums.Genre SongGenre { get; set; }
        public int SongLocationInPlaylist { get; set; }
    }
}