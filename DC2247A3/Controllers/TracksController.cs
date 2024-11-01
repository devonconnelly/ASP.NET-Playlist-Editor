using DC2247A3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DC2247A3.Controllers
{
    public class TracksController : Controller
    {
        private Manager m = new Manager();

        // GET: Tracks
        public ActionResult Index()
        {
            return View(m.TrackGetAllWithDetail());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            var obj = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            var albums = m.AlbumGetAll();
            var mediaTypes = m.MediaTypeGetAll();

            
            var formViewModel = new TrackAddFormViewModel
            {
                Albums = new SelectList(albums, "AlbumId", "Title"),
                MediaTypes = new SelectList(mediaTypes, "MediaTypeId", "Name")
            };

            return View(formViewModel);
        }

        // POST: Tracks/Create
        [HttpPost]
        public ActionResult Create(TrackAddViewModel newItem)
        {
            if (!ModelState.IsValid)
                return View(newItem);
            try
            {
                var addedItem = m.TrackAdd(newItem);
                if (addedItem == null)
                    return View(newItem);
                else
                    return RedirectToAction("Details", new { id = addedItem.TrackId });
            }
            catch
            {
                return View(newItem);
            }
        }
    }
}
