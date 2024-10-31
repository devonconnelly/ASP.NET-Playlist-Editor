using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DC2247A3.Models
{
    public class TrackAddFormViewModel
    {
        [StringLength(200)]
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int Milliseconds { get; set; }

        public int Bytes { get; set; }

        public SelectList Albums { get; set; }
        public SelectList MediaTypes { get; set; }
    }
}