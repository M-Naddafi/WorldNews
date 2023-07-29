using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web.Mvc;
using WorldNews.Core.DTOs;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Context;
using WorldNews.DataLayer.Models;

namespace WorldNews.Pages.NewsPanel
{
    public class EditNewsModel : PageModel
    {
        #region Services

        private WNewsContext _context;
        private INewsService _newsService;
        private IAccountService _accountService;
        public EditNewsModel(INewsService newsService, IAccountService accountService, WNewsContext context)
        {
            _newsService = newsService;
            _accountService = accountService;
            _context = context;
        }


        #endregion


        [BindProperty]
        public News selectedNews { get; set; }
        [BindProperty]
        public AddorEditNewsViewModel news { get; set; }
        [BindProperty]
        public IEnumerable<Section> sections { get; set; }
        [BindProperty]
        public int newsSectionId { get; set; }
        public void OnGet(int id)
        {

            selectedNews = _newsService.FindNewsById(id);

            news = new AddorEditNewsViewModel()
            {
                UserId = selectedNews.UserId,
                NewsId = selectedNews.NewsId,
                SectionId = selectedNews.SectionId,
                NewsTitle = selectedNews.NewsTitle,
                NewsDescription = selectedNews.NewsDescription,
                BreakingNews = selectedNews.BreakingNews,
                HighlightNews = selectedNews.HighlightNews,
            };

            sections = _context.Section.ToList();
        }

        public IActionResult OnPost()
        {



            News editnews = new News()
            {
                UserId = _accountService.GetUserIdByUserName(User.Identity.Name),
                NewsId = news.NewsId,
                SectionId = newsSectionId,
                NewsTitle = news.NewsTitle,
                NewsDescription = news.NewsDescription,
                BreakingNews = news.BreakingNews,
                CreateDate= DateTime.Now,
                HighlightNews = news.HighlightNews,
                NewsImage = selectedNews.NewsImage,
            };

            _newsService.EditNews(editnews, news.NewsImage);

            return RedirectToPage("Index");
        }
    }
}
