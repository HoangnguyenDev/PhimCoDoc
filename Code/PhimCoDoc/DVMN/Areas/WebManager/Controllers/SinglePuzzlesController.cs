using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DVMN.Data;
using DVMN.Models;

namespace DVMN.Areas.WebManager.Controllers
{
    [Area("WebManager")]
    public class SinglePuzzlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SinglePuzzlesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: WebManager/SinglePuzzles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SSinglePuzzle.Include(s => s.Image);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WebManager/SinglePuzzles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSinglePuzzle = await _context.SSinglePuzzle
                .Include(s => s.Image)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sSinglePuzzle == null)
            {
                return NotFound();
            }

            return View(sSinglePuzzle);
        }

        // GET: WebManager/SinglePuzzles/Create
        public IActionResult Create()
        {
            ViewData["ImageID"] = new SelectList(_context.Set<Image>(), "ID", "ID");
            return View();
        }

        // POST: WebManager/SinglePuzzles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Slug,ImageID,IsYesNo,AnswerA,AnswerB,AnswerC,AnswerD,Correct,Reason,Like,Level,CreateDT,UpdateDT,AuthorID,Approved,Active,IsDeleted,Note")] SSinglePuzzle sSinglePuzzle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sSinglePuzzle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ImageID"] = new SelectList(_context.Set<Image>(), "ID", "ID", sSinglePuzzle.ImageID);
            return View(sSinglePuzzle);
        }

        // GET: WebManager/SinglePuzzles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSinglePuzzle = await _context.SSinglePuzzle.SingleOrDefaultAsync(m => m.ID == id);
            if (sSinglePuzzle == null)
            {
                return NotFound();
            }
            ViewData["ImageID"] = new SelectList(_context.Set<Image>(), "ID", "ID", sSinglePuzzle.ImageID);
            return View(sSinglePuzzle);
        }

        // POST: WebManager/SinglePuzzles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Slug,ImageID,IsYesNo,AnswerA,AnswerB,AnswerC,AnswerD,Correct,Reason,Like,Level,CreateDT,UpdateDT,AuthorID,Approved,Active,IsDeleted,Note")] SSinglePuzzle sSinglePuzzle)
        {
            if (id != sSinglePuzzle.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sSinglePuzzle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SSinglePuzzleExists(sSinglePuzzle.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ImageID"] = new SelectList(_context.Set<Image>(), "ID", "ID", sSinglePuzzle.ImageID);
            return View(sSinglePuzzle);
        }

        // GET: WebManager/SinglePuzzles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSinglePuzzle = await _context.SSinglePuzzle
                .Include(s => s.Image)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sSinglePuzzle == null)
            {
                return NotFound();
            }

            return View(sSinglePuzzle);
        }

        // POST: WebManager/SinglePuzzles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sSinglePuzzle = await _context.SSinglePuzzle.SingleOrDefaultAsync(m => m.ID == id);
            _context.SSinglePuzzle.Remove(sSinglePuzzle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SSinglePuzzleExists(int id)
        {
            return _context.SSinglePuzzle.Any(e => e.ID == id);
        }
    }
}
