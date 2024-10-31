using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DC2247A3.Models
{
    public class TrackAddFormViewModel : TrackAddViewModel
    {
        
        public SelectList Albums { get; set; }
        public SelectList MediaTypes { get; set; }
    }
}