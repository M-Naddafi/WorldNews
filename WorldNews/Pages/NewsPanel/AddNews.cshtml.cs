using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using WorldNews.Core.DTOs;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Context;
using WorldNews.DataLayer.Models;

namespace WorldNews.Pages.NewsPanel
{
    public class AddNewsModel : PageModel
    {
        #region Services

        private WNewsContext _context;
        private INewsService _newsService;
        private IAccountService _accountService;
        public AddNewsModel(INewsService newsService, IAccountService accountService , WNewsContext context)
        {
            _newsService = newsService;
            _accountService = accountService;
            _context = context;
        }


        #endregion


        [BindProperty]
        public AddorEditNewsViewModel news { get; set; }
        [BindProperty]
        public IEnumerable<Section> sections { get; set; }

        public void OnGet()
        {
           sections = _context.Section.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            News addedNews= new News()
            {
                UserId = _accountService.GetUserIdByUserName(User.Identity.Name),
                SectionId = news.SectionId,
                NewsTitle = news.NewsTitle,
                NewsDescription = news.NewsDescription,
                BreakingNews = news.BreakingNews,
                HighlightNews = news.HighlightNews,
            };

            _newsService.AddNews(addedNews, news.NewsImage);

            return RedirectToPage("Index");
        }
    }
}
