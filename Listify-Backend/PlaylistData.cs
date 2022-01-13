using Listify_Backend.DataModels;
using System;
using System.Collections.Generic;

namespace Listify_Backend
{
    public class PlaylistData
    {
        public int PlaylistID { get; set; }
        public string PlaylistName { get; set; }
        public string PlayListIconString { get; set; }
        public string PlaylistTagsString { get; set; }

    }
}
