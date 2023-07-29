using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;
using WorldNews.Core.DTOs;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Models;

namespace WorldNews.Controllers
{
    public class NewsController : Controller
    {
        #region Services
        INewsService _newsService;
        IAccountService _accountService;
        public NewsController(INewsService newsService,IAccountService accountService)
        {
            _newsService = newsService;
            _accountService = accountService;
        }
        #endregion


        public News news { get; set; }
        public IEnumerable<News> sectionNews { get; set; }
        public IEnumerable<News> authorNews { get; set; }
        public IEnumerable<News> filteredNews { get; set; }
        public CommentViewModel commentViewModel { get; set; }


        [Route("News/{id}")]
        public IActionResult Index(int id)
        {
            news = _newsService.FindNewsById(id);
            return View(news);
        }

        [Route("Section/{id}/{name}")]
        public IActionResult Section(int id, string name)
        {
            ViewData["name"] = name;
            sectionNews = _newsService.GetSectionNews(id);
            return View(sectionNews);
        }

        [Route("Author/{name}")]
        public IActionResult Author(string name)
        {
            ViewData["name"] = name;
            authorNews = _newsService.GetAuthorNews(name);
            return View(authorNews);
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Search(string filterTitle)
        {
            ViewData["name"] = filterTitle;
            filteredNews = _newsService.GetNewsByFilter(filterTitle);
            return View(filteredNews);
        }

        [HttpPost]
        [Route("SubmitComment")]
        public IActionResult SubmitComment(int id,string comment)
        {
            commentViewModel = new CommentViewModel()
            {
                NewsId = id,
                UserId = _accountService.GetUserIdByUserName(User.Identity.Name),
                Comment= comment,
                CreateDate = DateTime.Now,
                Username = User.Identity.Name,
            };

            _newsService.AddComment(commentViewModel);

            return Redirect($"/News/{id}");
        }
    }
}
