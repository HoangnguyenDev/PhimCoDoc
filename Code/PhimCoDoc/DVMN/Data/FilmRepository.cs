using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVMN.Models;
using Microsoft.EntityFrameworkCore;
using DVMN.Models.FilmViewModels;
using Microsoft.AspNetCore.Identity;

namespace DVMN.Data
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Member> _userManager; 

        public FilmRepository(ApplicationDbContext context, UserManager<Member> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<CreateEditFilmViewModel> GetEdit(int? Id)
        {
            var post = _context.Film
                .Include(p => p.Image)
                .Include(p => p.Serie)
                .SingleOrDefault(p => p.ID == Id);
            if (post != null)
            {
                var tags = await _context.FilmTag.
                    Include(p => p.Tag).
                    Where(p => p.FilmID == post.ID).
                    ToListAsync();
                string tempTag = "";
                foreach (var item in tags)
                {
                    tempTag = tempTag+item.Tag.Title + ", ";
                }
                CreateEditFilmViewModel model = new CreateEditFilmViewModel
                {
                    Actor = post.Actor,
                    AuthorID = post.AuthorID,
                    DateofRease = post.DateofRease,
                    Description = post.Description,
                    DescriptionShort = post.DescriptionShort,
                    Director = post.Director,
                    ImageID = post.ImageID,
                    Info = post.Info,
                    IsProposed = post.IsProposed,
                    Watch = post.Watch,
                    Vote = post.Vote,
                    VideoTrailer = post.VideoTrailer,
                    VideoBackUp2 = post.VideoBackUp2,
                    VideoBackUp1 = post.VideoBackUp1,
                    Video = post.Video,
                    Length = post.Length,
                    Title = post.Title,
                    StarRating = post.StarRating,
                    Slug = post.Slug,
                    SerieID = post.SerieID,
                    OrtherTitle = post.OrtherTitle,
                    Genres = post.Genres,
                    TempTag = tempTag,
                    Image = post.Image,
                    Serie = post.Serie
                };
                return model;
            }
            return null;
        }

        public async Task Create(CreateEditFilmViewModel model)
        {
            var post = _context.Film.SingleOrDefault(p => p.ID == model.ID);

            if (post != null)
            {
                throw new ArgumentException("A post with the id of " + model.ID + " already exists.");
            }

            Film film = new Film
            {
                Active = "A",
                Actor = model.Actor,
                Approved = "A",
                AuthorID = model.AuthorID,
                CreateDT = DateTime.Now,
                IsDeleted = false,
                UpdateDT = DateTime.Now,
                DateofRease = model.DateofRease,
                Description = model.Description,
                DescriptionShort = model.DescriptionShort,
                Director = model.Director,
                ImageID = model.ImageID,
                Info = model.Info,
                IsProposed = model.IsProposed,
                Watch = model.Watch,
                Vote = model.Vote,
                VideoTrailer = model.VideoTrailer,
                VideoBackUp2 = model.VideoBackUp2,
                VideoBackUp1 = model.VideoBackUp1,
                Video = model.Video,
                Length = model.Length,
                Title = model.Title,
                StarRating = model.StarRating,
                Slug = model.Slug,
                SerieID = model.SerieID,
                OrtherTitle = model.OrtherTitle,
                Genres = model.Genres
            };
            _context.Film.Add(film);

            // Get and convert string to create tag
            List<string> listString = StringExtensions.ConvertStringToListString(model.TempTag);
            List<Tag> listTag = new List<Tag>(listString.Capacity - 1);

            // Save all tag
            foreach (var item in listString)
            {
                Tag tag = new Tag
                {
                    Title = item,
                    Slug = StringExtensions.ConvertToUnSign3(item)
                };
                _context.Add(tag);
                _context.Add(new FilmTag { TagID = tag.ID, FilmID = film.ID});
            }
            await _context.SaveChangesAsync();
        }
        public async Task SaveEdit(CreateEditFilmViewModel model)
        {
            var post = _context.Film.SingleOrDefault(p => p.ID == model.ID);

            //if (post != null)
            //{
            //    throw new ArgumentException("A post with the id of " + model.ID + " already exists.");
            //}

            Film film = new Film
            {
                Active = "A",
                Actor = model.Actor,
                Approved = "A",
                AuthorID = model.AuthorID,
                CreateDT = DateTime.Now,
                IsDeleted = false,
                UpdateDT = DateTime.Now,
                DateofRease = model.DateofRease,
                Description = model.Description,
                DescriptionShort = model.DescriptionShort,
                Director = model.Director,
                ImageID = model.ImageID,
                Info = model.Info,
                IsProposed = model.IsProposed,
                Watch = model.Watch,
                Vote = model.Vote,
                VideoTrailer = model.VideoTrailer,
                VideoBackUp2 = model.VideoBackUp2,
                VideoBackUp1 = model.VideoBackUp1,
                Video = model.Video,
                Length = model.Length,
                Title = model.Title,
                StarRating = model.StarRating,
                Slug = model.Slug,
                SerieID = model.SerieID,
                OrtherTitle = model.OrtherTitle,
                Genres = model.Genres,
                Note = post.Note
                
            };
            _context.Film.Remove(post);
            _context.Add(film);
            //_context.Film.Update(film);


            //Tim tat ca tag cu va tien hanh xoa
            var tags = await _context.FilmTag.
                    Include(p => p.Tag).
                    Where(p => p.FilmID == model.ID).
                    ToListAsync();
            foreach (var item in tags)
            {
                _context.FilmTag.Remove(item);
                var tag = await _context.Tag.SingleOrDefaultAsync(p => p.ID == item.TagID);
                _context.Tag.Remove(tag);
            }


            // Get and convert string to create tag
            List<string> listString = StringExtensions.ConvertStringToListString(model.TempTag);
            List<Tag> listTag = new List<Tag>(listString.Capacity - 1);


            // Save all tag
            foreach (var item in listString)
            {
                Tag tag = new Tag
                {
                    Title = item,
                    Slug = StringExtensions.ConvertToUnSign3(item)
                };
                _context.Add(tag);
                _context.Add(new FilmTag { TagID = tag.ID, FilmID = film.ID });
            }
            await _context.SaveChangesAsync();
        }



        public async Task Delete(int id)
        {
            var post = _context.Film
                .Include(f => f.Image)
                .Include(f => f.Member)
                .Include(f => f.Serie)
                .SingleOrDefault(m => m.ID == id);

            if (post == null)
            {
                throw new KeyNotFoundException("The post with the id of " + id + " does not exist");
            }

            _context.Film.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, Film updatedItem)
        {
            var post = _context.Film.SingleOrDefault(p => p.ID == id);

            if (post == null)
            {
                throw new KeyNotFoundException("A post with the id of "
                    + id + " does not exist in the data store.");
            }

            post.ID = updatedItem.ID;
            post.Title = updatedItem.Title;
            post.DescriptionShort = updatedItem.DescriptionShort;
            post.Description = updatedItem.Description;
            post.Length = updatedItem.Length;
            post.Vote = updatedItem.Vote;
            post.Actor = updatedItem.Actor;
            post.Director = updatedItem.Director;
            post.IsProposed = updatedItem.IsProposed;
            post.SerieID = updatedItem.SerieID;
            post.Slug = updatedItem.Slug;
            post.StarRating = updatedItem.StarRating;
            post.Video = updatedItem.Video;
            post.VideoBackUp1 = updatedItem.VideoBackUp1;
            post.VideoBackUp2 = updatedItem.VideoBackUp2;
            post.VideoTrailer = updatedItem.VideoTrailer;
            post.Watch = updatedItem.Watch;
            post.Length = updatedItem.Length;
            post.Info = updatedItem.Info;
            post.OrtherTitle = updatedItem.OrtherTitle;
            post.Genres = updatedItem.Genres;
            _context.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Film> Get(int? id)
        {
            return await _context.Film
                .Include(p => p.Member)
                .Include(f => f.Image)
                .Include(f => f.Serie)
                .SingleOrDefaultAsync(post => post.ID == id);
        }

        public async Task<WatchFilmViewModel> Get(string slug, string server)
        {

            var film = await _context.Film
               .Include(p => p.Member)
               .Include(f => f.Image)
               .Include(f => f.Serie)
               .SingleOrDefaultAsync(post => post.Slug == slug);

            var tags = await _context.FilmTag
                .Include(p => p.Film)
                .Include(p => p.Tag)
                .ToListAsync();
            WatchFilmViewModel model = new WatchFilmViewModel(film.Image,film.Member,film.Serie, tags);
            model.Video = film.Video;
            model.VideoBackUp1 = film.VideoBackUp1;
            model.Title = film.Title;
            model.OrtherTitle = film.OrtherTitle;
            model.Info = film.Info;
            model.IsProposed = film.IsProposed;
            model.DateofRease = film.DateofRease;
            model.Description = film.Description;
            model.DescriptionShort = film.DescriptionShort;
            model.Genres = film.Genres;
            model.Length = film.Length;
            model.StarRating = film.StarRating;
            model.VideoTrailer = film.VideoTrailer;
            model.Watch = film.Watch;
            model.Slug = film.Slug;
            model.SelectSever = Int32.Parse(server);
            return model;
        }

        public async Task<IEnumerable<Film>> GetAll()
        {
            return await _context.Film.Include(f => f.Image).Include(f => f.Member).Include(f => f.Serie)
                     .OrderByDescending(post => post.CreateDT).ToListAsync();
        }

        public async Task<IEnumerable<BannerBottomFilmViewModel>> GetBannerBottomFilm()
        {
            var listFilmDB = await _context.Film.Include(f => f.Image)
               .Include(f => f.Serie)
               .Where(p => !p.IsProposed && p.Approved == "A")
               .OrderByDescending(post => post.CreateDT).Take(10).ToListAsync();
            int leng = listFilmDB.Capacity;
            List<BannerBottomFilmViewModel> model = new List<BannerBottomFilmViewModel>(leng);
            foreach (var item in listFilmDB)
            {
                BannerBottomFilmViewModel tempItem = new BannerBottomFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                tempItem.OrtherTitle = item.OrtherTitle;
                tempItem.Slug = item.Slug;
                tempItem.DateOfRelease = item.DateofRease;
                model.Add(tempItem);
            }
            return model;
        }

        public async Task<IEnumerable<BannerFilmViewModel>> GetBannerFilm()
        {
            var listFilmDB = await _context.Film
                .Include(f => f.Image)
                .Include(f => f.Member)
                .Include(f => f.Serie)
                .Where(p => p.Approved == "A" && !p.IsProposed)
                .OrderByDescending(post => post.CreateDT).Take(5).ToListAsync();
            int leng = listFilmDB.Capacity;
            List<BannerFilmViewModel> model = new List<BannerFilmViewModel>(leng);
            foreach (var item in listFilmDB)
            {
                BannerFilmViewModel tempItem = new BannerFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                if(!String.IsNullOrEmpty(item.DescriptionShort))
                { 
                    if(item.DescriptionShort.Length > 160)
                    { 
                        tempItem.Descriptions = item.DescriptionShort.Substring(0, 160);
                    }
                    else
                        tempItem.Descriptions = item.DescriptionShort.Substring(0, item.DescriptionShort.Length-1);
                }
                tempItem.Slug = item.Slug;
                model.Add(tempItem);
            }
            return model;
        }

        public async Task<DownloadFilmViewModel> GetDownloadFilm(string Slug)
        {
            var item = await _context.Film.Include(f => f.Image)
                .Where(p => p.Slug == Slug && !p.IsProposed && p.Approved == "A").SingleOrDefaultAsync();
            return new DownloadFilmViewModel
            {
                Slug = item.Slug,
                DescriptionShort = item.DescriptionShort,
                OrtherTitle = item.OrtherTitle,
                Title = item.Title
            ,
                Video = item.Video,
                VideoBackUp1 = item.VideoBackUp1,
                VideoBackUp2 = item.VideoBackUp2,
                Image = item.Image
            };
        }

        public async Task<IEnumerable<GeneralFilmViewModel>> GetGeneralFilm()
        {
            var listFilmDB = await _context.Film.Include(f => f.Image)
               .Include(f => f.Serie)
               .Where(p => !p.IsProposed && p.Approved == "A")
               .OrderByDescending(post => post.Watch).Take(10).ToListAsync();
            int leng = listFilmDB.Capacity;
            List<GeneralFilmViewModel> model = new List<GeneralFilmViewModel>(leng);
            foreach (var item in listFilmDB)
            {
                GeneralFilmViewModel tempItem = new GeneralFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                tempItem.OrtherTitle = item.OrtherTitle;
                tempItem.Watch = item.Watch;
                tempItem.Slug = item.Slug;
                tempItem.Info = item.Info;
                tempItem.DateOfRelease = item.DateofRease;
                model.Add(tempItem);
            }
            return model;
        }

        public DbSet<Images> GetImages()
        {
            return _context.Images;
        }

        public async Task<IEnumerable<ListProposalFilmViewModel>> GetListProposalFilm()
        {
            var listFilmDB = await _context.Film.Include(f => f.Image)
                .Include(f => f.Serie)
                .Where(p => p.Approved == "A" && p.IsProposed)
                .OrderByDescending(post => post.Vote).Take(8).ToListAsync();
            int leng = listFilmDB.Capacity;
            List<ListProposalFilmViewModel> model = new List<ListProposalFilmViewModel>(leng);
            foreach (var item in listFilmDB)
            {
                ListProposalFilmViewModel tempItem = new ListProposalFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                tempItem.OrtherTitle = item.OrtherTitle;
                tempItem.Vote = item.Vote;
                tempItem.ID = item.ID;
                tempItem.Slug = item.Slug;
                model.Add(tempItem);
            }
            return model;
        }

        public async Task<IEnumerable<ListSelectorFilmViewModel>> GetListSelectorFilm(string key)
        {
            List<Film> listFilmDb;
            if (key == "Full")
            {
                listFilmDb = await _context.Film.Include(f => f.Image)
              .Include(f => f.Serie)
              .Where(p => p.Approved == "A" && !p.IsProposed)
              .OrderByDescending(post => post.DateofRease.Value.Year).ToListAsync();
            }
            else
            {
                listFilmDb = await _context.Film.Include(f => f.Image)
                .Include(f => f.Serie)
                .Where(p => p.Approved == "A" && !p.IsProposed && p.Title.Contains(key))
                .OrderByDescending(post => post.DateofRease.Value.Year).ToListAsync();
            }

            int leng = listFilmDb.Count;
            List<ListSelectorFilmViewModel> model = new List<ListSelectorFilmViewModel>(leng);
            foreach (var item in listFilmDb)
            {
                ListSelectorFilmViewModel tempItem = new ListSelectorFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                tempItem.Slug = item.Slug;
                tempItem.DateOfRelease = item.DateofRease;
                tempItem.Genre = item.Genres;
                tempItem.OrtherTitle = item.OrtherTitle;
                tempItem.Status = item.Info;
                tempItem.Watch = item.Watch;
                model.Add(tempItem);
            }
            return model;
        }

        public DbSet<Member> GetMembers()
        {
            return _context.Users;
        }

        public async Task<IEnumerable<ProposalFilmViewModel>> GetProposalFilm()
        {
            var listFilmDB = await _context.Film.Include(f => f.Image)
                .Include(f => f.Serie)
                .Where(p => p.IsProposed && p.Approved == "A")
                .OrderByDescending(post => post.Watch).Take(10).ToListAsync();
            int leng = listFilmDB.Capacity;
            List<ProposalFilmViewModel> model = new List<ProposalFilmViewModel>(leng);
            foreach (var item in listFilmDB)
            {
                ProposalFilmViewModel tempItem = new ProposalFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                if (!String.IsNullOrEmpty(item.Description))
                {
                    tempItem.Description = item.DescriptionShort.Substring(0, 160);
                }
                tempItem.Vote = item.Vote;
                tempItem.ID = item.ID;
                tempItem.Slug = item.Slug;
                tempItem.DateOfRelease = item.DateofRease;
                tempItem.VideoTrailler = item.VideoTrailer;
                tempItem.Genres = item.Genres;
                model.Add(tempItem);
            }
            return model;
        }

        public DbSet<Serie> GetSeries()
        {
            return _context.Serie;
        }

        public async Task<IEnumerable<SingleRightPartialFilmViewModel>> GetSingleRightFilms()
        {
            var listFilmDB = await _context.Film.Include(f => f.Image)
                .Include(f => f.Serie)
                .Where(p => p.Approved == "A" && !p.IsProposed)
                .OrderByDescending(post => post.Watch).Take(8).ToListAsync();
            int leng = listFilmDB.Capacity;
            List<SingleRightPartialFilmViewModel> model = new List<SingleRightPartialFilmViewModel>(leng);
            foreach (var item in listFilmDB)
            {
                SingleRightPartialFilmViewModel tempItem = new SingleRightPartialFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                if (!String.IsNullOrEmpty(item.DescriptionShort))
                {
                    if(item.DescriptionShort.Length > 160)
                        tempItem.Description = item.DescriptionShort.Substring(0, 160);
                    else
                        tempItem.Description = item.DescriptionShort.Substring(0, item.DescriptionShort.Length);
                }
                tempItem.Watch = item.Watch;
                tempItem.Slug = item.Slug;
                model.Add(tempItem);
            }
            return model;
        }

        public async Task<IEnumerable<WatchALotFilmViewModel>> GetWatchALotFilm()
        {
            var listFilmDB = await _context.Film.Include(f => f.Image)
                .Where(p => p.Approved == "A" && !p.IsProposed)
                .OrderByDescending(post => post.Watch).ToListAsync();
            int leng = listFilmDB.Capacity;
            List<WatchALotFilmViewModel> model = new List<WatchALotFilmViewModel>(leng);
            foreach (var item in listFilmDB)
            {
                WatchALotFilmViewModel tempItem = new WatchALotFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                tempItem.OrtherTitle = item.Title;
                tempItem.Watch = item.Watch;
                tempItem.Slug = item.Slug;
                tempItem.Info = item.Info;
                model.Add(tempItem);
            }
            return model;
        }

        public async Task<IEnumerable<WatchALotFilmViewModel>> GetFilmsInTag(string slug)
        {
            var tagId = (await _context.Tag.SingleAsync(p => p.Slug == slug)).ID;
            var listFilmInTag = await _context.FilmTag
                .Where(p => p.TagID == tagId)
                .ToListAsync();

            List<WatchALotFilmViewModel> model = new List<WatchALotFilmViewModel>(listFilmInTag.Capacity - 1);

            foreach (var item in listFilmInTag)
            {
                var film = await _context.Film
                    .Include( p => p.Image)
                    .SingleOrDefaultAsync(p => p.ID == item.FilmID);
                if (film != null)
                { 
                    WatchALotFilmViewModel tempItem = new WatchALotFilmViewModel(film.Image);
                    tempItem.Title = film.Title;
                    tempItem.OrtherTitle = film.Title;
                    tempItem.Watch = film.Watch;
                    tempItem.Slug = film.Slug;
                    tempItem.Info = film.Info;
                    model.Add(tempItem);
                }

            }
            return model;
        }

        public async Task IsWatched(string slug)
        {
            var item = await _context.Film.SingleOrDefaultAsync(p => p.Slug == slug);
            if (item != null)
            {
                item.Watch++;
                _context.Film.Update(item);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<WatchALotFilmViewModel>> GetSearchFilms(string search)
        {
            var listFilmDB = await _context.Film.Include(f => f.Image)
                .Where(p => p.Approved == "A" && !p.IsProposed && p.Title.Contains(search))
                .OrderByDescending(post => post.Watch).ToListAsync();
            if (listFilmDB == null)
            {
                listFilmDB = await _context.Film.Include(f => f.Image)
                                .Where(p => p.Approved == "A" && !p.IsProposed && p.OrtherTitle.Contains(search))
                                .OrderByDescending(post => post.Watch).ToListAsync();
            }

            int leng = listFilmDB.Capacity;
            List<WatchALotFilmViewModel> model = new List<WatchALotFilmViewModel>(leng);
            foreach (var item in listFilmDB)
            {
                WatchALotFilmViewModel tempItem = new WatchALotFilmViewModel(item.Image);
                tempItem.Title = item.Title;
                tempItem.OrtherTitle = item.Title;
                tempItem.Watch = item.Watch;
                tempItem.Slug = item.Slug;
                tempItem.Info = item.Info;
                model.Add(tempItem);
            }
            return model;
        }
    }
}
