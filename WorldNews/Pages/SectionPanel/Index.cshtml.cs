using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Models;

namespace WorldNews.Pages.SectionPanel
{
    public class IndexModel : PageModel
    {

        #region Services


        private INewsService _newsService;
        public IndexModel(INewsService newsService)
        {
            _newsService = newsService;
        }


        #endregion


        public IEnumerable<Section> Sections { get; set; }

        public void OnGet()
        {
            Sections = _newsService.GetAllSections();
        }
    }
}
