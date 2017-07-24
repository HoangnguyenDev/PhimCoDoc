using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models.FilmViewModels
{
    public class SingleRightPartialFilmViewModel
    {
        public SingleRightPartialFilmViewModel(Images image)
        {
            this.Image = image;
        }
        public Images Image { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int Watch { get; set; }
        public string Title { get; set; }
    }
}
