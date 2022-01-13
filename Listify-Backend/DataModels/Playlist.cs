using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Listify_Backend.DataModels
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        public int PlaylistCode { get; set; }
        public string PlaylistName { get; set; }
        public List<Songs> PlaylistSongs { get; set; }
        public string PlayListIconString { get; set; }
        public string PlaylistTagsString { get; set; }
    }
}
