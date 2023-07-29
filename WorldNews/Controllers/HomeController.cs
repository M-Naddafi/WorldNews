using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldNews.DataLayer.Context;
using WorldNews.DataLayer.Models;

namespace WorldNews.Controllers
{
    public class HomeController : Controller
    {

        #region Context


        private WNewsContext _context;
        public HomeController(WNewsContext context)
        {
            _context = context;
        }


        #endregion

        public IEnumerable<News> news { get; set; }
        public IActionResult Index()
        {
            news = _context.News.Include(n => n.User).Include(n => n.Section);
            return View(news);
        }

    }
}
