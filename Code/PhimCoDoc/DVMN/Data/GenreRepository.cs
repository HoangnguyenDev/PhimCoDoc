using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Data
{
    public class GenreRepository : IGenreRepository
    {
        protected readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<string> GetAll()
        {

            return null;//_context.Film.SelectMany(post => post.Genres).Distinct();
        }

        public string Get(string tag)
        {
            //var posts = _context.Film.Where(post =>
            //    post.Genres.Contains(tag, StringComparer.CurrentCultureIgnoreCase))
            //    .ToList();

            //if (!posts.Any())
            //{
            //    throw new KeyNotFoundException("The tag " + tag + " does not exist.");
            //}

            //return tag.ToLower();
            return null;
        }

        public void Edit(string existingTag, string newTag)
        {

            //    var posts = _context.Film.Where(post =>
            //        post.Genres.Contains(existingTag, StringComparer.CurrentCultureIgnoreCase))
            //        .ToList();

            //    if (!posts.Any())
            //    {
            //        throw new KeyNotFoundException("The tag " + existingTag + " does not exist.");
            //    }

            //    foreach (var post in posts)
            //    {
            //        post.Genres.Remove(existingTag);
            //        post.Genres.Add(newTag);
            //    }

            //_context.SaveChanges();
            //return null;
        }

        public void Delete(string tag)
        {

            //var posts = _context.Film.Where(post =>
            //    post.Genres.Contains(tag, StringComparer.CurrentCultureIgnoreCase))
            //    .ToList();

            //if (!posts.Any())
            //{
            //    throw new KeyNotFoundException("The tag " + tag + " does not exist.");
            //}

            //foreach (var post in posts)
            //{
            //    post.Genres.Remove(tag);
            //}

            //_context.SaveChanges();
            //return null;
        }
    }
}
