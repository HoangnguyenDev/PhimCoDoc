using DVMN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Services
{
    public interface IMultiPuzzle
    {
        //List<PuzzleType> GetPuzzleType();
        Task<MMultiPuzzle> Get(int? id);
        bool Exists(int id);
        Task<List<MMultiPuzzle>> GetAll();
        Task Add(MMultiPuzzle model);
        Task Update(MMultiPuzzle model);
        Task Delete(int id);

    }
}
