using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVMN.Data;
using DVMN.Models;

namespace DVMN.Controllers
{
    public class ProposalsFilmController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProposalsFilmController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<string> Send(string name, string reson)
        {
            _context.Add(new ProposalsFilm { Name = name, Reason = reson});
            await _context.SaveChangesAsync();
            return "1";
        }
    }
}