using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models
{
    public class FilmTag
    {
        public int FilmID { get; set; }

        public Film Film { get; set; }
        public int TagID { get; set; }

        public Tag Tag { get; set; }
    }
}
