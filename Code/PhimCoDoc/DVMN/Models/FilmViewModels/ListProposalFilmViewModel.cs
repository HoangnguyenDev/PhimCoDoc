using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models.FilmViewModels
{
    public class ListProposalFilmViewModel
    {
        public ListProposalFilmViewModel(Images image)
        {
            Image = image;
        }
        public int ID { get; set; }
        public Images Image { get; set; }
        public string Title { get; set; }

        public string OrtherTitle { get; set; }

        public string Info { get; set; }
        public int Vote { get; set; }
    }
}
