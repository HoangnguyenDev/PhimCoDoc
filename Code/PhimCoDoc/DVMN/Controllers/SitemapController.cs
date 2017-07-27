using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVMN.Data;
using DVMN.Services;
using Microsoft.EntityFrameworkCore;

namespace DVMN.Controllers
{
    public class SitemapController : Controller
    {
        private readonly ApplicationDbContext _blogService;
        public SitemapController(ApplicationDbContext blogService)
        {
            _blogService = blogService;
        }

        [Route("sitemap.xml")]
        public async Task<ActionResult> SitemapAsync()
        {
            string root = "http://phimcodoc.net/";
            string filmRoot = "http://phimcodoc.net/phim/";
            string downloadFilm = "http://phimcodoc.net/tai-phim/";
            string watchFilm = "http://phimcodoc.net/xem-phim/";
            string ImagesRoot = "http://phimcodoc.net/images/";
            string Images115x175 = "http://phimcodoc.net/images/115x175/";
            string Images182x268 = "http://phimcodoc.net/images/182x268/";
            string Images268x268 = "http://phimcodoc.net/images/268x268/";
            string Images640x351 = "http://phimcodoc.net/images/640x351/";
            string Images1140x641 = "http://phimcodoc.net/images/1140x641/";
            string Images1300x500 = "http://phimcodoc.net/images/1300x500/";
            // get a list of published articles
            var films = await _blogService.Film.ToListAsync();

            var images = await _blogService.Images.ToListAsync();

            // get last modified date of the home page
            var siteMapBuilder = new SitemapBuilder();

            // add the home page to the sitemap
            siteMapBuilder.AddUrl(root, modified: DateTime.UtcNow, changeFrequency: ChangeFrequency.Weekly, priority: 1.0);

            // add the blog posts to the sitemap
            foreach (var film in films)
            {
                siteMapBuilder.AddUrl(filmRoot + film.Slug, modified: film.CreateDT, changeFrequency: null, priority: 0.9);
                siteMapBuilder.AddUrl(downloadFilm + film.Slug, modified: film.CreateDT, changeFrequency: null, priority: 0.9);
                siteMapBuilder.AddUrl(watchFilm + film.Slug, modified: film.CreateDT, changeFrequency: null, priority: 0.9);
            }
            

            foreach (var image in images)
            {
                siteMapBuilder.AddUrl(ImagesRoot + image.Name, modified: image.CreateDT, changeFrequency: null, priority: 0.9);
                siteMapBuilder.AddUrl(Images115x175 + image.Name, modified: image.CreateDT, changeFrequency: null, priority: 0.9);
                siteMapBuilder.AddUrl(Images182x268 + image.Name, modified: image.CreateDT, changeFrequency: null, priority: 0.9);
                siteMapBuilder.AddUrl(Images268x268 + image.Name, modified: image.CreateDT, changeFrequency: null, priority: 0.9);
                siteMapBuilder.AddUrl(Images1140x641 + image.Name, modified: image.CreateDT, changeFrequency: null, priority: 0.9);
                siteMapBuilder.AddUrl(Images1300x500 + image.Name, modified: image.CreateDT, changeFrequency: null, priority: 0.9);
                siteMapBuilder.AddUrl(Images640x351 + image.Name, modified: image.CreateDT, changeFrequency: null, priority: 0.9);
            }

            // generate the sitemap xml
            string xml = siteMapBuilder.ToString();
            return Content(xml, "text/xml");
        }
    }
}