using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVMN.Data;

namespace DVMN.Areas.WebManager.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository _repository;
        public GenreController(IGenreRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin/genre
        public ActionResult Index()
        {
            var genres = _repository.GetAll();
            return View(genres);
        }

        [HttpGet]
        public ActionResult Edit(string genre)
        {
            try
            {
                var model = _repository.Get(genre);
                return View(model);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string genre, string newgenre)
        {
            var genres = _repository.GetAll();

            if (!genres.Contains(genre))
            {
                return NotFound();
            }

            if (genres.Contains(newgenre))
            {
                return RedirectToAction("index");
            }

            if (string.IsNullOrWhiteSpace(newgenre))
            {
                ModelState.AddModelError("key", "New genre value cannot be empty.");

                return View(genre);
            }

            _repository.Edit(genre, newgenre);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Delete(string genre)
        {
            try
            {
                var model = _repository.Get(genre);
                return View(model);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string genre, bool foo)
        {
            try
            {
                _repository.Delete(genre);

                return RedirectToAction("index");
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
        }
    }
}