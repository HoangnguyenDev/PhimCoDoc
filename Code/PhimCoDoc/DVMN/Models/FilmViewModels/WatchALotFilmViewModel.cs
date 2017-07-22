using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models.FilmViewModels
{
    public class WatchALotFilmViewModel
    {
        public WatchALotFilmViewModel(Images image)
        {
            Image = image;
        }
        public Images Image { get; set; }
        public string Title { get; set; }
        public string OrtherTitle { get; set; }
        public string Slug { get; set; }
        public string Info { get; set; }
        public int Watch { get; set; }
    }
}
