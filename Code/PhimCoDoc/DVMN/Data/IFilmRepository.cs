using DVMN.Models;
using DVMN.Models.FilmViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Data
{
    public interface IFilmRepository
    {
        Task<DownloadFilmViewModel> GetDownloadFilm(string Slug);
        Task<IEnumerable<ListSelectorFilmViewModel>> GetListSelectorFilm(string key);
        Task<IEnumerable<ListProposalFilmViewModel>> GetListProposalFilm();
        Task<IEnumerable<GeneralFilmViewModel>> GetGeneralFilm();
        Task<IEnumerable<BannerBottomFilmViewModel>> GetBannerBottomFilm();
        Task<IEnumerable<ProposalFilmViewModel>> GetProposalFilm();
        Task<IEnumerable<BannerFilmViewModel>> GetBannerFilm();
        Task<IEnumerable<SingleRightPartialFilmViewModel>> GetSingleRightFilms();
        Task<Film> Get(int? id);
        Task<WatchFilmViewModel> Get(string slug, string server);
        Task Edit(int id, Film updatedItem);
        Task Create(Film model);
        Task Delete(int id);
        Task<IEnumerable<Film>> GetAll();
        DbSet<Member> GetMembers();
        DbSet<Images> GetImages();
        DbSet<Serie> GetSeries();
    }
}
