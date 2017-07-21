using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DVMN.Data;
using DVMN.Models;
using Microsoft.AspNetCore.Identity;

namespace DVMN.Areas.WebManager.Controllers
{
    [Area("WebManager")]
    public class FilmController : Controller
    {
        private readonly IFilmRepository _repository;
        private UserManager<Member> _userManager;

        public FilmController(IFilmRepository repository, UserManager<Member> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        [Route("/quan-ly-web/phim")]
        public async Task<IActionResult> Index()
        {
            var posts = await _repository.GetAll();
            return View(posts);
        }

        // GET: WebManager/Film/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _repository.Get(id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: WebManager/Film/Create
        [Route("/quan-ly-web/phim/tao-moi")]
        public IActionResult Create()
        {
            ViewData["ImageID"] = new SelectList(_repository.GetImages(), "ID", "Name");
            ViewData["AuthorID"] = new SelectList(_repository.GetMembers(), "Id", "FullName");
            ViewData["SerieID"] = new SelectList(_repository.GetSeries(), "ID", "Name");
            return View();
        }

        // POST: WebManager/Film/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/quan-ly-web/phim/tao-moi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,OrtherTitle,Description, DescriptionShort,DateofRease,Info,Length,Watch,StarRating,Video, VideoBackUp1, VideoBackUp2,VideoTrailer,Slug,ImageID,SerieID,Genres,CreateDT,UpdateDT,AuthorID,Approved,Active,IsDeleted,Note,IsProposed,Actor,Director")] Film film)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                film.AuthorID = user.Id;
                await _repository.Create(film);
                return RedirectToAction("Index");
            }
            ViewData["ImageID"] = new SelectList(_repository.GetImages(), "ID", "Name", film.ImageID);
            ViewData["AuthorID"] = new SelectList(_repository.GetMembers(), "Id", "FullName", film.AuthorID);
            ViewData["SerieID"] = new SelectList(_repository.GetSeries(), "ID", "ID", film.SerieID);
            return View(film);
        }

        // GET: WebManager/Film/Edit/5
        [Route("/quan-ly-web/phim/chinh-sua/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _repository.Get(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["ImageID"] = new SelectList(_repository.GetImages(), "ID", "Name");
            ViewData["AuthorID"] = new SelectList(_repository.GetMembers(), "Id", "FullName");
            ViewData["SerieID"] = new SelectList(_repository.GetSeries(), "ID", "ID");
            return View(film);
        }

        // POST: WebManager/Film/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/quan-ly-web/phim/chinh-sua/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,OrtherTitle,Description, DescriptionShort,DateofRease,Info,Length,Watch,StarRating,Video, VideoBackUp1, VideoBackUp2,VideoTrailer,Slug,ImageID,SerieID,Genres,CreateDT,UpdateDT,AuthorID,Approved,Active,IsDeleted,Note,IsProposed,Actor,Director")] Film film)
        {
            if (id != film.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Edit(id,film);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        throw;
                }
                return RedirectToAction("Index");
            }
            ViewData["ImageID"] = new SelectList(_repository.GetImages(), "ID", "ID", film.ImageID);
            ViewData["AuthorID"] = new SelectList(_repository.GetMembers(), "Id", "Id", film.AuthorID);
            ViewData["SerieID"] = new SelectList(_repository.GetSeries(), "ID", "ID", film.SerieID);
            return View(film);
        }

        // GET: WebManager/Film/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _repository.Get(id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: WebManager/Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
