using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Listify_Backend.DAL
{
    public interface IPlaylistDataDAL
    {
        public List<DataModels.Playlist> GetPlaylists();
        public List<DataModels.Songs> GetSongs();
        public void CreatePlaylist(string playlistName, List<DataModels.Songs> playlistSongs, int playlistCode, string playlistIconString, string playlistTagsString);
        public int GeneratePlaylistCode();
    }
}
