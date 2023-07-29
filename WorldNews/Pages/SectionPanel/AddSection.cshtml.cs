using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Models;

namespace WorldNews.Pages.SectionPanel
{
    public class AddSectionModel : PageModel
    {

        #region Services


        private INewsService _newsService;
        public AddSectionModel(INewsService newsService)
        {
            _newsService = newsService;
        }


        #endregion


        [BindProperty]
        public Section section { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _newsService.AddSection(section);
            return RedirectToPage("Index");
        }
    }
}
