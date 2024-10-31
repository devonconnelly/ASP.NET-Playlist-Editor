using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DC2247A3.Models
{
    public class PlaylistEditTracksFormViewModel
    {
        public int PlaylistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public ICollection<TrackBaseViewModel> ExistingTracks { get; set; }

        public MultiSelectList AvailableTracks { get; set; }
    }
}