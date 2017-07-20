using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models.FilmViewModels
{
    public class BannerFilmViewModel
    {
        public string Title { get; set; }
        public string Descriptions { get; set; }

        public string Slug { get; set; }

        public string ImageID { get; set; }

        public Images Image { get; set; }

        public BannerFilmViewModel(Images image)
        {
            this.Image = image;
        }
    }
}
