using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldNews.Core.DTOs;
using WorldNews.Core.Services;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Context;
using WorldNews.DataLayer.Models;

namespace WorldNews.Pages.NewsPanel
{
    public class DeleteNewsModel : PageModel
    {
        #region Services

        private WNewsContext _context;
        private INewsService _newsService;
        private IAccountService _accountService;

        public DeleteNewsModel(INewsService newsService, WNewsContext context, IAccountService accountService)
        {
            _newsService = newsService;
            _context = context;
            _accountService = accountService;
        }


        #endregion


        [BindProperty]
        public News selectedNews { get; set; }
        [BindProperty]
        public AddorEditNewsViewModel news { get; set; }


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
        }

        public IActionResult OnPost()
        {
            News editnews = new News()
            {
                UserId = _accountService.GetUserIdByUserName(User.Identity.Name),
                NewsId = news.NewsId,
                SectionId = selectedNews.SectionId,
                NewsTitle = news.NewsTitle,
                NewsDescription = news.NewsDescription,
                BreakingNews = news.BreakingNews,
                HighlightNews = news.HighlightNews,
                NewsImage = selectedNews.NewsImage
            };
            _newsService.DeleteNews(editnews);
            return RedirectToPage("Index");
        }
    }
}
