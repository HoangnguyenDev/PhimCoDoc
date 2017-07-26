using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVMN.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;
using System.Text;

namespace DVMN.Controllers
{
    [ResponseCache(Duration = 30)]
    public class HomeController : Controller
    {
        private readonly IFilmRepository _repository;

        public HomeController(IFilmRepository repository)
        {
            _repository = repository;
        }

        [ResponseCache(CacheProfileName = "Default")]
        public async Task<IActionResult> Index()
        {
            ViewData["bannerFilm"] = await _repository.GetBannerFilm();
            ViewData["bannerBottomFilm"] = await _repository.GetBannerBottomFilm();
            ViewData["generalFilm"] = await _repository.GetGeneralFilm();
            ViewData["proposalFilm"] = await _repository.GetProposalFilm();
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [ResponseCache(Duration = 60)]

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                var statusFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
                if (statusFeature != null)
                {
                    //Log.LogWarning("handled 404 for url: {OriginalPath}", statusFeature.OriginalPath);
                }
                return View(statusCode);
            }
            return View(statusCode);
        }
        [Route("/danh-sach-phim")]
        public async Task<IActionResult> List()
        {
            ViewData["All"] = await _repository.GetListSelectorFilm("Full");
            ViewData["A"] = await _repository.GetListSelectorFilm("A");
            ViewData["B"] = await _repository.GetListSelectorFilm("B");
            ViewData["C"] = await _repository.GetListSelectorFilm("C");
            ViewData["D"] = await _repository.GetListSelectorFilm("D");
            ViewData["E"] = await _repository.GetListSelectorFilm("E");
            ViewData["F"] = await _repository.GetListSelectorFilm("F");
            ViewData["G"] = await _repository.GetListSelectorFilm("G");
            ViewData["H"] = await _repository.GetListSelectorFilm("H");
            ViewData["I"] = await _repository.GetListSelectorFilm("I");
            ViewData["J"] = await _repository.GetListSelectorFilm("J");
            ViewData["K"] = await _repository.GetListSelectorFilm("K");
            ViewData["L"] = await _repository.GetListSelectorFilm("L");
            ViewData["M"] = await _repository.GetListSelectorFilm("M");
            ViewData["N"] = await _repository.GetListSelectorFilm("N");
            ViewData["O"] = await _repository.GetListSelectorFilm("O");
            ViewData["P"] = await _repository.GetListSelectorFilm("P");
            ViewData["Q"] = await _repository.GetListSelectorFilm("Q");
            ViewData["R"] = await _repository.GetListSelectorFilm("R");
            ViewData["S"] = await _repository.GetListSelectorFilm("S");
            ViewData["T"] = await _repository.GetListSelectorFilm("T");
            ViewData["U"] = await _repository.GetListSelectorFilm("U");
            ViewData["V"] = await _repository.GetListSelectorFilm("V");
            ViewData["W"] = await _repository.GetListSelectorFilm("W");
            ViewData["X"] = await _repository.GetListSelectorFilm("X");
            ViewData["Y"] = await _repository.GetListSelectorFilm("Y");
            ViewData["Z"] = await _repository.GetListSelectorFilm("Z");

            return View();
        }

        [Route("/phim-xem-nhieu")]
        public async Task<IActionResult> WatchALot()
        {
            return View(await _repository.GetWatchALotFilm());
        }

        [Route("/sap-ra-mat")]
        public async Task<IActionResult> ProposalFilm()
        {
            return View(await _repository.GetListProposalFilm());
        }

        [Route("robots.txt", Name = "GetRobotsText")]
        public ContentResult RobotsText()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("user-agent: *");
            stringBuilder.AppendLine("disallow: /Areas/");
            return this.Content(stringBuilder.ToString(), "text/plain", Encoding.UTF8);
        }
        [Route("/tim-kiem/")]
        public async Task<IActionResult> SearchPhim(string Search)
        {
            ViewData["Search"] = Search;

            return View(await _repository.GetSearchFilms(Search));
        }

        //public IActionResult NotFound()
        //{
        //    return View();
        //}
        //public IActionResult Unauthorized()
        //{
        //    return View();
        //}
    }
}
