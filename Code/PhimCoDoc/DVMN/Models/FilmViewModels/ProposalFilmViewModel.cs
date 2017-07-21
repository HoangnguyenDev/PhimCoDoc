using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models.FilmViewModels
{
    public class ProposalFilmViewModel
    {
        public ProposalFilmViewModel(Images image)
        {
            Image = image;
        }
        public int ID { get; set; }
        public Images Image { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DateOfRelease { get; set; }

        public string Genres { get; set; }
        public int Vote { get; set; }
    }
}
