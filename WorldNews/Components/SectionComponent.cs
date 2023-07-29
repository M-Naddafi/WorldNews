using Microsoft.AspNetCore.Mvc;
using WorldNews.Core.Services.Interfaces;

namespace WorldNews.Components
{
    public class SectionComponent : ViewComponent
    {
        #region Services


        private INewsService _newsService;
        public SectionComponent(INewsService newsService)
        {
            _newsService= newsService;
        }


        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/SectionComponent.cshtml", _newsService.GetAllSections());
        }
    }
}