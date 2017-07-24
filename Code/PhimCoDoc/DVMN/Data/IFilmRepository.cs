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
        //Tim kiem phim
        Task<IEnumerable<WatchALotFilmViewModel>> GetSearchFilms(string search);

        //Lay thong tin de chinh sua phim
        Task<CreateEditFilmViewModel> GetEdit(int? Id);
        Task SaveEdit(CreateEditFilmViewModel model);

        //Phim trong the 
        Task<IEnumerable<WatchALotFilmViewModel>> GetFilmsInTag(string slug);
        //Phim da xem
        Task IsWatched(string slug);
        //Phim xem nhiều
        Task<IEnumerable<WatchALotFilmViewModel>> GetWatchALotFilm();
        Task<DownloadFilmViewModel> GetDownloadFilm(string Slug);
        Task<IEnumerable<ListSelectorFilmViewModel>> GetListSelectorFilm(string key);
        Task<IEnumerable<ListProposalFilmViewModel>> GetListProposalFilm();

        // danh sach phim ngay trang dau
        Task<IEnumerable<GeneralFilmViewModel>> GetGeneralFilm();
        //danh sách phim ngay ben duoi banner
        Task<IEnumerable<BannerBottomFilmViewModel>> GetBannerBottomFilm();
        //danh sach phim de cu
        Task<IEnumerable<ProposalFilmViewModel>> GetProposalFilm();
        Task<IEnumerable<BannerFilmViewModel>> GetBannerFilm();
        Task<IEnumerable<SingleRightPartialFilmViewModel>> GetSingleRightFilms();
        Task<Film> Get(int? id);
        Task<WatchFilmViewModel> Get(string slug, string server);
        Task Edit(int id, Film updatedItem);
        Task Create(CreateEditFilmViewModel model);
        Task Delete(int id);
        Task<IEnumerable<Film>> GetAll();
        DbSet<Member> GetMembers();
        DbSet<Images> GetImages();
        DbSet<Serie> GetSeries();
    }
}
