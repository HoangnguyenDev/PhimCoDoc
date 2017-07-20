using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVMN.Models;
using Microsoft.EntityFrameworkCore;
using DVMN.Models.FilmViewModels;
using Microsoft.AspNetCore.Identity;

namespace DVMN.Data
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Member> _userManager; 

        public FilmRepository(ApplicationDbContext context, UserManager<Member> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
       

        public async Task Create(Film model)
        {
            var post = _context.Film.SingleOrDefault(p => p.ID == model.ID);

            if (post != null)
            {
                throw new ArgumentException("A post with the id of " + model.ID + " already exists.");
            }
            model.CreateDT = DateTime.Now;
            model.Approved = "A";
            model.Active = "A";
            model.UpdateDT = DateTime.Now;
            _context.Film.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var post = _context.Film
                .Include(f => f.Image)
                .Include(f => f.Member)
                .Include(f => f.Serie)
                .SingleOrDefault(m => m.ID == id);

            if (post == null)
            {
                throw new KeyNotFoundException("The post with the id of " + id + " does not exist");
            }

            _context.Film.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, Film updatedItem)
        {
            var post = _context.Film.SingleOrDefault(p => p.ID == id);

            if (post == null)
            {
                throw new KeyNotFoundException("A post with the id of "
                    + id + " does not exist in the data store.");
            }

            post.ID = updatedItem.ID;
            post.Title = updatedItem.Title;
            post.DescriptionShort = updatedItem.DescriptionShort;
            post.Description = updatedItem.Description;
            post.Length = updatedItem.Length;
            post.SerieID = updatedItem.SerieID;
            post.Slug = updatedItem.Slug;
            post.StarRating = updatedItem.StarRating;
            post.Video = updatedItem.Video;
            post.VideoBackUp1 = updatedItem.VideoBackUp1;
            post.VideoBackUp2 = updatedItem.VideoBackUp2;
            post.VideoTrailer = updatedItem.VideoTrailer;
            post.Watch = updatedItem.Watch;
            post.Length = updatedItem.Length;
            post.Info = updatedItem.Info;
            post.OrtherTitle = updatedItem.OrtherTitle;
            post.Genres = updatedItem.Genres;
            _context.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Film> Get(int? id)
        {
            return await _context.Film
                .Include(p => p.Member)
                .Include(f => f.Image)
                .Include(f => f.Serie)
                .SingleOrDefaultAsync(post => post.ID == id);
        }

        public async Task<WatchFilmViewModel> Get(string slug, string server)
        {

            var film = await _context.Film
               .Include(p => p.Member)
               .Include(f => f.Image)
               .Include(f => f.Serie)
               .SingleOrDefaultAsync(post => post.Slug == slug);
            WatchFilmViewModel model = new WatchFilmViewModel(film.Image,film.Member,film.Serie);
            model.Video = film.Video;
            model.VideoBackUp1 = film.VideoBackUp1;
            model.Title = film.Title;
            model.OrtherTitle = film.OrtherTitle;
            model.Info = film.Info;
            model.DateofRease = film.DateofRease;
            model.Description = film.Description;
            model.DescriptionShort = film.DescriptionShort;
            model.Genres = film.Genres;
            model.Length = film.Length;
            model.StarRating = film.StarRating;
            model.VideoTrailer = film.VideoTrailer;
            model.Watch = film.Watch;
            model.Slug = film.Slug;
            model.SelectSever = Int32.Parse(server);
            return model;
        }

        public async Task<IEnumerable<Film>> GetAll()
        {
            return await _context.Film.Include(f => f.Image).Include(f => f.Member).Include(f => f.Serie)
                     .OrderByDescending(post => post.CreateDT).ToListAsync();
        }

        public async Task<IEnumerable<BannerFilmViewModel>> GetBannerFilm()
        {
            var listFilmDB = await _context.Film.Include(f => f.Image).Include(f => f.Member).Include(f => f.Serie)
                     .OrderByDescending(post => post.CreateDT).Take(8).ToListAsync();
            int leng = listFilmDB.Capacity;
            List<BannerFilmViewModel> model = new List<BannerFilmViewModel>(leng);
            foreach (var item in listFilmDB)
            {
                BannerFilmViewModel tempItem = new BannerFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                if(!String.IsNullOrEmpty(item.Description))
                { 
                    tempItem.Descriptions = item.DescriptionShort.Substring(0, 160);
                }
                tempItem.Slug = item.Slug;
                model.Add(tempItem);
            }
            return model;
        }

        public DbSet<Images> GetImages()
        {
            return _context.Images;
        }
        public DbSet<Member> GetMembers()
        {
            return _context.Users;
        }
        public DbSet<Serie> GetSeries()
        {
            return _context.Serie;
        }

        public async Task<IEnumerable<SingleRightPartialFilmViewModel>> GetSingleRightFilms()
        {
            var listFilmDB = await _context.Film.Include(f => f.Image)
                .Include(f => f.Serie)
                .OrderByDescending(post => post.Watch).Take(8).ToListAsync();
            int leng = listFilmDB.Capacity;
            List<SingleRightPartialFilmViewModel> model = new List<SingleRightPartialFilmViewModel>(leng);
            foreach (var item in listFilmDB)
            {
                SingleRightPartialFilmViewModel tempItem = new SingleRightPartialFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                if (!String.IsNullOrEmpty(item.Description))
                {
                    tempItem.Description = item.DescriptionShort.Substring(0, 160);
                }
                tempItem.Watch = item.Watch;
                tempItem.Slug = item.Slug;
                model.Add(tempItem);
            }
            return model;
        }
    }
}
