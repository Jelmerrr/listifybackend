using Microsoft.VisualStudio.TestTools.UnitTesting;
using Listify_Backend;
using Listify_UnitTests.Stubs;
using System.Collections.Generic;

namespace Listify_UnitTests
{
    [TestClass]
    public class PlaylistDataTests
    {
        [TestMethod]
        public void GetPlaylists_Get3Playlists_ReturnsTrue()
        {
            bool has3Playlists;
            PlaylistDataDALStub playlistDataDALStub = new PlaylistDataDALStub();
            var playlists = playlistDataDALStub.GetPlaylists();
            if(playlists.Count == 3)
            {
                has3Playlists = true;
            }
            else
            {
                has3Playlists = false;
            }
            Assert.AreEqual(true, has3Playlists);
        }
        [TestMethod]
        public void GetSongs_Get6Songs_ReturnsTrue()
        {
            bool has6Songs;
            PlaylistDataDALStub playlistDataDALStub = new PlaylistDataDALStub();
            var songs = playlistDataDALStub.GetSongs();
            if (songs.Count == 6)
            {
                has6Songs = true;
            }
            else
            {
                has6Songs = false;
            }
            Assert.AreEqual(true, has6Songs);
        }
        [TestMethod]
        public void GeneratePlaylistCode_CheckForDuplicateCodes_ReturnsFalse()
        {
            bool hasDuplicate = true;
            PlaylistDataDALStub playlistDataDALStub = new PlaylistDataDALStub();
            int returnedCode = playlistDataDALStub.GeneratePlaylistCode();
            var playlists = playlistDataDALStub.GetPlaylists();
            foreach (var item in playlists)
            {
                if (item.PlaylistCode == returnedCode)
                {
                    hasDuplicate = true;
                }
                else
                {
                    hasDuplicate = false;
                }
            }
             
            Assert.AreEqual(false, hasDuplicate);
        }
    }
}
