using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models.FilmViewModels
{
    public class DownloadFilmViewModel
    {
        public string Title { get; set; }

        public Images Image { get; set; }
        public string OrtherTitle { get; set; }
        public string DescriptionShort { get; set; }

        public string Video { get; set; }

        public string VideoBackUp1 { get; set; }

        public string VideoBackUp2 { get; set; }

        public string Slug { get; set; }
    }
}
