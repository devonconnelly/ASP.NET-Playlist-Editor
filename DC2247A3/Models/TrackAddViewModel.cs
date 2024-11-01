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
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(220)]
        [Required]
        public string Composer { get; set; }

        [Display(Name = "Unit price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Length (ms)")]
        public int Milliseconds { get; set; }

        public int Bytes { get; set; }

        [Display(Name = "Album")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select an album.")]
        public int AlbumId { get; set; }

        [Display(Name = "Media Type")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a media type.")]
        public int MediaTypeId { get; set; }
    }
}