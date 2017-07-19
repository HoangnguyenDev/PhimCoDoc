using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVMN.Models;
using Microsoft.EntityFrameworkCore;

namespace DVMN.Data
{
    public class FilmRepository : IFilmRepository
    {
        private ApplicationDbContext _context;

        public FilmRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Film model)
        {
            var post = _context.Film.SingleOrDefault(p => p.ID == model.ID);

            if (post != null)
            {
                throw new ArgumentException("A post with the id of " + model.ID + " already exists.");
            }

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

        public async Task<Film> Get(string slug)
        {
            return await _context.Film
               .Include(p => p.Member)
               .Include(f => f.Image)
               .Include(f => f.Serie)
               .SingleOrDefaultAsync(post => post.Slug == slug);
        }

        public async Task<IEnumerable<Film>> GetAll()
        {
            return await _context.Film.Include(f => f.Image).Include(f => f.Member).Include(f => f.Serie)
                     .OrderByDescending(post => post.CreateDT).ToListAsync();
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
    }
}
