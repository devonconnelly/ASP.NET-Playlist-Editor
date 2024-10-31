using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DC2247A3.Controllers
{
    public class AlbumsController : Controller
    {

        private Manager m = new Manager();

        // GET: Albums
        public ActionResult Index()
        {
            return View(m.AlbumGetAll());
        }
    }
}
