using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DC2247A3.Models
{
    public class TrackBaseViewModel
    {
        [Key]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        [Display(Name = "Length (ms)")]
        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        [Display(Name = "Unit price")]
        public decimal UnitPrice { get; set; }
    }
}