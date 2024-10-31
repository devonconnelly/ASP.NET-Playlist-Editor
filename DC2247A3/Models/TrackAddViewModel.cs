using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DC2247A3.Models
{
    public class TrackAddViewModel
    {
        [StringLength(200)]
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
    }
}