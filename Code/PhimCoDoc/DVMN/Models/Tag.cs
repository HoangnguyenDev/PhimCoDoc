using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models
{
    public class Tag : Base
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Slug { get; set; }

        public string SinglePuzzleDetailsID { get; set; }
        public MSinglePuzzleDetails SinglePuzzleDetails { get; set; }
    }
}
