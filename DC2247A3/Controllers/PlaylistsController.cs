using DC2247A3.Data;
using DC2247A3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DC2247A3.Controllers
{
    public class PlaylistsController : Controller
    {
        private Manager m = new Manager();

        // GET: Playlists
        public ActionResult Index()
        {
            return View(m.PlaylistGetAll());
        }

        // GET: Playlists/Details/5
        public ActionResult Details(int? id)
        {
            var obj = m.PlaylistGetById(id.GetValueOrDefault());

            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }

        // GET: Playlists/Edit/5
        public ActionResult Edit(int? id)
        {
            var obj = m.PlaylistGetById(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();
            var formObj = m.mapper.Map<PlaylistBaseViewModel, PlaylistEditTracksFormViewModel>(obj);

            formObj.AvailableTracks = new MultiSelectList(m.TrackGetAll(), "TrackId", "NameFull");

            formObj.SelectedTrackIds = obj.Tracks.Select(t => t.TrackId).ToList();
            formObj.ExistingTracks = m.mapper.Map<ICollection<Track>, ICollection<TrackBaseViewModel>>(obj.Tracks);

            return View(formObj);
        }

        // POST: Playlists/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, PlaylistEditTracksViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = model.PlaylistId });
            }
            if (id.GetValueOrDefault() != model.PlaylistId)
            {
                return RedirectToAction("Index");
            }
            var editedItem = m.PlaylistEditTracks(model);
            if (editedItem == null)
            {
                return RedirectToAction("Edit", new { id = model.PlaylistId });
            }
            else
            {
                return RedirectToAction("Details", new { id = model.PlaylistId });
            }
        }

        // GET: Playlists/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Playlists/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
