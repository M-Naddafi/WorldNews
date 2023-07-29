using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldNews.Core.DTOs;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Context;
using WorldNews.DataLayer.Models;

namespace WorldNews.Pages.NewsPanel
{
    public class IndexModel : PageModel
    {
        #region Services


        private INewsService _service;
        public IndexModel(INewsService service)
        {
            _service = service;
        }


        #endregion


        public NewsPanelViewModel news { get; set; }

        public void OnGet(int pageId = 1, string filterTitle = "", string filterSection = "")
        {
            news = _service.GetNewsForNewsPanel(pageId, filterTitle, filterSection);
        }
    }
}
