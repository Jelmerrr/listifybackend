using Listify_Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Listify_Backend.DAL
{
    public class PlaylistDataDAL : IPlaylistDataDAL
    {
        public List<DataModels.Playlist> GetPlaylists()
        {
            using Context myContext = new Context();
            var Playlists = myContext
            .Playlists
            .ToList();
            return Playlists;
        }
        public List<DataModels.Songs> GetSongs()
        {
            using Context myContext = new Context();
            var Songs = myContext
            .Songs
            .ToList();
            return Songs;
        }
        public void CreatePlaylist(string playlistName, List<DataModels.Songs> playlistSongs, int playlistCode, string playlistIconString, string playlistTagsString)
        {
            using Context myContext = new Context();
            myContext.Playlists.Add(new Playlist()
            {
                PlaylistCode = playlistCode,
                PlaylistName = playlistName,
                PlaylistSongs = playlistSongs,
                PlayListIconString = playlistIconString,
                PlaylistTagsString = playlistTagsString
            });
            myContext.SaveChanges();
            
        }
        public int GeneratePlaylistCode()
        {
            var rng = new Random();
            int code = rng.Next(0, 100);
            using Context myContext = new Context();
            var Playlists = myContext
                .Playlists
                .Where(c => c.PlaylistCode == code)
                .ToList();
            if (Playlists.Count != 0)
            {
                GeneratePlaylistCode();
            }
            return code;
        }
    }
}
