using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVMN.Models;
using DVMN.Data;
using Microsoft.EntityFrameworkCore;

namespace DVMN.Services
{
    public class MultiPuzzleRepository : IMultiPuzzle
    {
        protected readonly ApplicationDbContext _context;
        public MultiPuzzleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(MMultiPuzzle model)
        {
            _context.Add(model);
            await Save();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MMultiPuzzle> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MMultiPuzzle>> GetAll()
        {
            return await _context.MultiPuzzle.ToListAsync();
        }

        //public Task<List<MultiPuzzle>> GetAll()
        //{
        //    return _context.Puzzle.ToListAsync();

        //}

        public Task Update(MMultiPuzzle model)
        {
            throw new NotImplementedException();
        }

        //public List<PuzzleType> GetPuzzleType()
        //{
        //    return _context.PuzzleType.ToList();
        //}

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
