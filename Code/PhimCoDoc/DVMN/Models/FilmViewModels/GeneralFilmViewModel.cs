using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models.FilmViewModels
{
    public class GeneralFilmViewModel
    {
        public GeneralFilmViewModel(Images image)
        {
            this.Image = image;
        }
        public string Slug { get; set; }
        public Images Image { get; set; }
        public string Info { get; set; }
        public int Watch { get; set; }
        public string Title { get; set; }
        public string OrtherTitle { get; set; }
        public DateTime? DateOfRelease { get; set; }
    }
}
