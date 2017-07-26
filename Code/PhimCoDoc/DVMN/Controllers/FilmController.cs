using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVMN.Data;
using Microsoft.EntityFrameworkCore;

namespace DVMN.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmRepository _repository;

        public FilmController(IFilmRepository repository)
        {
            _repository = repository;
        }

        [Route("/phim/{slug}")]
        public async Task<IActionResult> Single(string slug)
        {
            ViewData["FilmDetials"] = await _repository.Get(slug, "1");
            ViewData["SingleRightFilm"] = await _repository.GetSingleRightFilms();
            ViewData["bannerBottomFilm"] = await _repository.GetBannerBottomFilm();
            await _repository.IsWatched(slug);
            return View();
        }
        [Route("/xem-phim/{slug}")]
        public async Task<IActionResult> Watch(string server, string slug)
        {
            if (String.IsNullOrEmpty(server))
                server = "1";
            ViewData["FilmDetials"] = await _repository.Get(slug, server);
            ViewData["bannerBottomFilm"] = await _repository.GetBannerBottomFilm();
            return View();
        }

        [Route("/tai-phim/{slug}")]
        public async Task<IActionResult> Download(string slug)
        {
            ViewData["FilmDetials"] = await _repository.GetDownloadFilm(slug);
            ViewData["SingleRightFilm"] = await _repository.GetSingleRightFilms();
            ViewData["bannerBottomFilm"] = await _repository.GetBannerBottomFilm();
            return View();
        }
        [Route("phim/the/{slug}")]
        public async Task<IActionResult> Tag ( string slug)
        {
            ViewData["Tag"] = slug;
            return View(await _repository.GetFilmsInTag(slug));
        }


    }
}