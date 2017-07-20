using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVMN.Data;
using Microsoft.EntityFrameworkCore;
using DVMN.Models;

namespace DVMN.Controllers
{
    public class FeedbackTranslateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbackTranslateController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<string> Send(string slug, string timeError, string name)
        {
            var film = await _context.Film.SingleOrDefaultAsync(p => p.Slug == slug);
            if (film != null)
            {
                _context.Add(new FeedbackTranslate { Name = name, TimeError = timeError, FilmID = film.ID });
                await _context.SaveChangesAsync();
            }
            return "1";
        }

    }
}