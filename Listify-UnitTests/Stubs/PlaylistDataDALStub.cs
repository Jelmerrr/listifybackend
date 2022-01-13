using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listify_Backend.DAL;
using Listify_Backend.DataModels;
using Listify_Backend.Enums;


namespace Listify_UnitTests.Stubs
{
    class PlaylistDataDALStub : IPlaylistDataDAL
    {
        public List<Playlist> GetPlaylists()
        {
            List<Playlist> dummyPlaylists = new List<Playlist>()
            {
                new Playlist()
                {
                    PlaylistID = 1,
                    PlaylistName = "Chill",
                    PlaylistTagsString = "Nice,Mood,Relaxed,Ambient,Nature",
                    PlayListIconString = "Icon.png",
                    PlaylistCode = 34
                },
                new Playlist()
                {
                    PlaylistID = 2,
                    PlaylistName = "Dance",
                    PlaylistTagsString = "Electronic,FeelGood,Happy",
                    PlayListIconString = "Icon.png",
                    PlaylistCode = 12
                },
                new Playlist()
                {
                    PlaylistID = 3,
                    PlaylistName = "Classic Rock",
                    PlaylistTagsString = "Nostalgia,Cool,Nice",
                    PlayListIconString = "Icon.png",
                    PlaylistCode = 83
                }
            };
            return dummyPlaylists;
        }
        public List<Songs> GetSongs()
        {
            List<Songs> dummySongs = new List<Songs>()
            {
                new Songs
                {
                    SongArtist = "009",
                    SongTitle = "Dreamscape",
                    SongGenre = Genre.Electronic,
                    SongLocationInPlaylist = 34
                },
                new Songs
                {
                    SongArtist = "Owl City",
                    SongTitle = "Cool Owl sounds",
                    SongGenre = Genre.Ambient,
                    SongLocationInPlaylist = 34
                },
                new Songs
                {
                    SongArtist = "TheFatRat",
                    SongTitle = "Unity",
                    SongGenre = Genre.Electronic,
                    SongLocationInPlaylist = 12
                },
                new Songs
                {
                    SongArtist = "Gebroeders ko",
                    SongTitle = "Toeter op m'n waterscooter",
                    SongGenre = Genre.Pop,
                    SongLocationInPlaylist = 12
                },
                new Songs
                {
                    SongArtist = "Sum41",
                    SongTitle = "In too deep",
                    SongGenre = Genre.Rock,
                    SongLocationInPlaylist = 83
                },
                new Songs
                {
                    SongArtist = "Blur",
                    SongTitle = "Song 2",
                    SongGenre = Genre.Rock,
                    SongLocationInPlaylist = 83
                }
            };
            return dummySongs;
        }
        public void CreatePlaylist(string playlistName, List<Songs> playlistSongs, int playlistCode, string playlistIconString, string playlistTagsString)
        {
            
            List<Playlist> dummyPlaylists = GetPlaylists();
            dummyPlaylists.Add(new Playlist
            { 
                PlaylistID = 4,
                PlaylistName = playlistName,
                PlaylistSongs = playlistSongs,
                PlaylistCode = GeneratePlaylistCode(),
                PlayListIconString = playlistIconString,
                PlaylistTagsString = playlistTagsString
        });
            List<Songs> dummySongs = GetSongs();
            foreach (var item in playlistSongs)
            {
                dummySongs.Add(item);
            }

        }
        public int GeneratePlaylistCode()
        {
            var rng = new Random();
            int code = rng.Next(0, 100);
            var Playlists = GetPlaylists();
            foreach(var item in Playlists)
            {
                if(item.PlaylistCode == code)
                {
                    GeneratePlaylistCode();
                }
            }
            return code;
        }
    }
}
