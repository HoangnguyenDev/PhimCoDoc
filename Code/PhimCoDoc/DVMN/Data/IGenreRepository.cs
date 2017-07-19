using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Data
{
    public interface IGenreRepository
    {
        IEnumerable<string> GetAll();
        string Get(string tag);

        void Edit(string existingTag, string newTag);

        void Delete(string tag);
    }
}
