using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DVMN.Services;
using DVMN.Models;
using Microsoft.AspNetCore.Authorization;
using DVMN.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DVMN.Areas.WebManager.Controllers
{
    [Area("WebManager")]
    [Authorize]
    public class MultiPuzzleController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IMultiPuzzle _multiPuzzle;
        private readonly UserManager<Member> _userManager;
        public MultiPuzzleController(
            ApplicationDbContext context,
            UserManager<Member> userManager,
            IMultiPuzzle multiPuzzle)
        {
            _context = context;
            _userManager = userManager;
            _multiPuzzle = multiPuzzle;
        }
        [Route("/quan-ly-web/nhieu-cau-hoi")]
        public async Task<IActionResult> Index()
        {
            return View(await _multiPuzzle.GetAll());
        }
        [Route("/quan-ly-web/nhieu-cau-hoi/tao")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("/quan-ly-web/nhieu-cau-hoi/tao")]
        [HttpPost]
        public IActionResult Create([Bind("Title,Description,NumberQuestion,Image,Slug")] MMultiPuzzle model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObjectAsJson("MultiPuzzle", model);
                
                return RedirectToAction("CreateMulti");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SaveAll()
        {
            try
            {
                var sMultiPuzzle = HttpContext.Session.GetObjectFromJson<MMultiPuzzle>("MultiPuzzle");
                var sListSinglePuzzleDetails = HttpContext.Session.GetObjectFromJson<List<Temp>>("listSinglePuzzleDetails");
                var user = await GetCurrentUserAsync();
                MMultiPuzzle multipuzzle = new MMultiPuzzle
                {
                    Active = "1",
                    Approved = "1",
                    MemberID = user.Id,
                    CreateDT = DateTime.Now,
                    Description = sMultiPuzzle.Description,
                    Image = sMultiPuzzle.Image,
                    IsDeleted = false,
                    Like = 0,
                    UpdateDT = DateTime.Now,
                    Title = sMultiPuzzle.Title,
                    NumberQuestion = sMultiPuzzle.NumberQuestion,
                    Slug = sMultiPuzzle.Slug,
                    Note = "",
                    Level = 1
                };
                List<MSinglePuzzleDetails> listSinglePuzzleDetails = new List<MSinglePuzzleDetails>(multipuzzle.NumberQuestion - 1);
                _context.Add(multipuzzle);
                foreach (var item in sListSinglePuzzleDetails)
                {
                    MSinglePuzzleDetails singlePuzzleDetails = new MSinglePuzzleDetails
                    {
                        Active = multipuzzle.Active,
                        Note = multipuzzle.Note,
                        Title = item.Title,
                        Description = item.Description,
                        IsYesNo = item.IsYesNo,
                        MMultiPuzzleID = multipuzzle.ID,
                        AnswerA = item.AnswerA,
                        AnswerB = item.AnswerB,
                        AnswerC = item.AnswerC,
                        AnswerD = item.AnswerD,
                        Correct = item.Correct,
                        Image = item.Image,
                        IsDeleted = false,
                        CreateDT = DateTime.Now,
                        Approved = "A",
                    };
                    _context.Add(singlePuzzleDetails);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string error = e.StackTrace;
            }
            return RedirectToAction("Index", "MultiPuzzle");
        }

        public IActionResult CreateMulti()
        {
            var multiPuzzle = HttpContext.Session.GetObjectFromJson<MMultiPuzzle>("MultiPuzzle");
            var listSinglePuzzleDetails = HttpContext.Session.GetObjectFromJson<List<Temp>>("listSinglePuzzleDetails");
            if (listSinglePuzzleDetails == null)
            {

                List<Temp> list = new List<Temp>(multiPuzzle.NumberQuestion - 1);
                for (int i = 0; i <= multiPuzzle.NumberQuestion - 1; i++)
                {
                    list.Add(new Temp { ID = i });
                }
                ViewData["listSinglePuzzleDetails"] = list.ToList();
                HttpContext.Session.SetObjectAsJson("listSinglePuzzleDetails", list);
            }
            else
            {
                ViewData["listSinglePuzzleDetails"] = listSinglePuzzleDetails.ToList();
            }
            ViewData["NumberQuestion"] = multiPuzzle.NumberQuestion;
            return View();
        }
        [HttpPost]
        [Route("sendData")]
        public IActionResult SaveTemp(Temp temp, string id)
        {
            var oldListSinglePuzzleDetails = HttpContext.Session.GetObjectFromJson<List<Temp>>("listSinglePuzzleDetails");
            var multiPuzzle = HttpContext.Session.GetObjectFromJson<MMultiPuzzle>("MultiPuzzle");

            //luu gia tri moi vao session
            List<Temp> newListSinglePuzzleDetails = new List<Temp>(multiPuzzle.NumberQuestion - 1);
            foreach (var item in oldListSinglePuzzleDetails)
            {
                if (item.ID == Int32.Parse(id))
                {
                    item.Title = temp.Title;
                    item.Description = temp.Description;
                    item.Image = temp.Image;
                    item.AnswerA = temp.AnswerA;
                    item.AnswerB = temp.AnswerB;
                    item.AnswerC = temp.AnswerC;
                    item.AnswerD = temp.AnswerD;
                    item.Correct = temp.Correct;
                    item.IsYesNo = temp.IsYesNo;
                }
                newListSinglePuzzleDetails.Add(item);
            }
            HttpContext.Session.SetObjectAsJson("listSinglePuzzleDetails", newListSinglePuzzleDetails);
            ViewData["listSinglePuzzleDetails"] = newListSinglePuzzleDetails.ToList();

            var serializedJsonModel = JsonConvert.SerializeObject(newListSinglePuzzleDetails.ToList());
            return Json(serializedJsonModel);
        }


        private Task<Member> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
    
}