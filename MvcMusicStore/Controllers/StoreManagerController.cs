using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace MvcMusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        MvcMusicStore.Models.MusicStoreEntities storeDB
              = new MvcMusicStore.Models.MusicStoreEntities();
        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = storeDB.Albums;

            return View(albums.ToList());
        }
        public ActionResult Edit(int id)

        {
            MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            

            return View(album);

        }

        [HttpPost]

        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                storeDB.Entry(album).State = System.Data.Entity.EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }
        public ViewResult Details(int id)

        {

            MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);

            return View(album);

        }

        public ActionResult Delete(int id)

        {

            MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);

            return View(album);



        }
        [HttpPost, ActionName("Delete")]

        public ActionResult Delete(int id, FormCollection collection)

        {

            try

            {

                // TODO: Add delete logic here
                MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);
                storeDB.Albums.Remove(album);

                storeDB.SaveChanges();



                return RedirectToAction("Index");

            }

            catch

            {

                return View();

            }

        }
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                storeDB.Albums.Add(album);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }
    }
}