using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models.FilmViewModels
{
    public class ListSelectorFilmViewModel
    {
        public string Title { get; set; }
        public string OrtherTitle { get; set; }
        public string Status { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public string Genre { get; set; }
        public int Watch { get; set; }
        public Images Image { get; set; }
        public string Slug { get; set; }
        public ListSelectorFilmViewModel(Images image)
        {
            Image = image;
        }
    }
}
