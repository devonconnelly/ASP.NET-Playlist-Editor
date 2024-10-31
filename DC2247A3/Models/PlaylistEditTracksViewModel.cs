using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DC2247A3.Models
{
    public class PlaylistEditTracksViewModel
    {
        public int PlaylistId { get; set; }

        public List<int> SelectedTrackIds { get; set; }
    }
}