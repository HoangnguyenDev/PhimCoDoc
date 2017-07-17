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
    public class SinglePuzzleDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SinglePuzzleDetailsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: WebManager/SinglePuzzleDetails1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SinglePuzzleDetails.Include(s => s.MultiPuzzle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WebManager/SinglePuzzleDetails1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singlePuzzleDetails = await _context.SinglePuzzleDetails
                .Include(s => s.MultiPuzzle)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (singlePuzzleDetails == null)
            {
                return NotFound();
            }

            return View(singlePuzzleDetails);
        }

        // GET: WebManager/SinglePuzzleDetails1/Create
        public IActionResult Create()
        {
            ViewData["MultiPuzzleID"] = new SelectList(_context.MultiPuzzle, "ID", "Description");
            return View();
        }

        // POST: WebManager/SinglePuzzleDetails1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Image,IsYesNo,AnswerA,AnswerB,AnswerC,AnswerD,Correct,Reason,MultiPuzzleID,CreateDT,UpdateDT,AuthorID,Approved,Active,IsDeleted,Note")] MSinglePuzzleDetails singlePuzzleDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(singlePuzzleDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["MultiPuzzleID"] = new SelectList(_context.MultiPuzzle, "ID", "Description", singlePuzzleDetails.MMultiPuzzleID);
            return View(singlePuzzleDetails);
        }

        // GET: WebManager/SinglePuzzleDetails1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singlePuzzleDetails = await _context.SinglePuzzleDetails.SingleOrDefaultAsync(m => m.ID == id);
            if (singlePuzzleDetails == null)
            {
                return NotFound();
            }
            ViewData["MultiPuzzleID"] = new SelectList(_context.MultiPuzzle, "ID", "Description", singlePuzzleDetails.MMultiPuzzleID);
            return View(singlePuzzleDetails);
        }

        // POST: WebManager/SinglePuzzleDetails1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Image,IsYesNo,AnswerA,AnswerB,AnswerC,AnswerD,Correct,Reason,MultiPuzzleID,CreateDT,UpdateDT,AuthorID,Approved,Active,IsDeleted,Note")] MSinglePuzzleDetails singlePuzzleDetails)
        {
            if (id != singlePuzzleDetails.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singlePuzzleDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinglePuzzleDetailsExists(singlePuzzleDetails.ID))
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
            ViewData["MultiPuzzleID"] = new SelectList(_context.MultiPuzzle, "ID", "Description", singlePuzzleDetails.MMultiPuzzleID);
            return View(singlePuzzleDetails);
        }

        // GET: WebManager/SinglePuzzleDetails1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singlePuzzleDetails = await _context.SinglePuzzleDetails
                .Include(s => s.MultiPuzzle)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (singlePuzzleDetails == null)
            {
                return NotFound();
            }

            return View(singlePuzzleDetails);
        }

        // POST: WebManager/SinglePuzzleDetails1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singlePuzzleDetails = await _context.SinglePuzzleDetails.SingleOrDefaultAsync(m => m.ID == id);
            _context.SinglePuzzleDetails.Remove(singlePuzzleDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SinglePuzzleDetailsExists(int id)
        {
            return _context.SinglePuzzleDetails.Any(e => e.ID == id);
        }
    }
}
