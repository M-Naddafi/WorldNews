using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Models;

namespace WorldNews.Pages.SectionPanel
{
    public class EditSectionModel : PageModel
    {
        #region Services


        private INewsService _newsService;
        public EditSectionModel(INewsService newsService)
        {
            _newsService = newsService;
        }


        #endregion


        [BindProperty]
        public Section section { get; set; }

        public void OnGet(int id)
        {
            section = _newsService.FindSectionBySectionId(id);
        }

        public IActionResult OnPost()
        {
            _newsService.EditSection(section);
            return RedirectToPage("Index");
        }
    }
}
