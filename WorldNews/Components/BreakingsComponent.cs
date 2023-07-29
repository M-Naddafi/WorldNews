using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Context;
using WorldNews.DataLayer.Models;

namespace WorldNews.Components
{
    public class BreakingsComponent : ViewComponent
    {
        #region Services


        private WNewsContext _context;
        public BreakingsComponent(WNewsContext context)
        {
            _context = context;
        }


        #endregion

        public IEnumerable<News> News { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            News = _context.News.Where(n => n.BreakingNews).OrderBy(n => n.CreateDate).Reverse().Take(3).Include(n => n.Section).Include(n => n.User);
            return View("/Views/Components/BreakingsComponent.cshtml", News);
        }
    }
}
