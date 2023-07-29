using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldNews.Core.Generator;
using WorldNews.Core.DTOs;
using WorldNews.Core.Generator;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Context;
using WorldNews.DataLayer.Models;
using System.Web.Mvc;
using Azure;

namespace WorldNews.Core.Services
{
    public class NewsService : INewsService
    {
        #region Context


        private WNewsContext _context;
        public NewsService(WNewsContext context)
        {
            _context = context;
        }


        #endregion


        public NewsPanelViewModel GetNewsForNewsPanel(int pageId = 1, string filterTitle = "", string filterSection = "")
        {
            IQueryable<News> result = _context.News.Include(n => n.Section);

            if (!string.IsNullOrEmpty(filterTitle))
            {
                result = result.Where(n => n.NewsTitle.Contains(filterTitle));
            }

            if (!string.IsNullOrEmpty(filterSection))
            {
                result = result.Where(u => u.Section.SectionName.Contains(filterSection));
            }

            // Show Item In Page
            int take = 20;
            int skip = (pageId - 1) * take;


            NewsPanelViewModel list = new NewsPanelViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.News = result.OrderBy(n => n.CreateDate).Skip(skip).Take(take).ToList();
            list.Sections = result.Select(n => n.Section).ToList();

            return list;
        }


        public IEnumerable<Section> GetAllSections()
        {
            return _context.Section.ToList();
        }


        public News FindNewsById(int newsId)
        {
            var news = _context.News.Include(n => n.Section).Include(n => n.User).Include(n => n.Comments);
            return news.First(n => n.NewsId == newsId);
        }


        public int AddNews(News news, IFormFile newsImageup)
        {
            news.CreateDate = DateTime.Now;
            if (newsImageup != null)
            {
                news.NewsImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(newsImageup.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/news/image", news.NewsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    newsImageup.CopyTo(stream);
                }
            }
            _context.Add(news);
            _context.SaveChanges();

            return news.NewsId;
        }


        public void EditNews(News news, IFormFile newsImageup)
        {

            if (news.NewsImage != null)
            {
                string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/news/image", news.NewsImage);
                if (File.Exists(deleteimagePath))
                {
                    File.Delete(deleteimagePath);
                }

                news.NewsImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(newsImageup.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/news/image", news.NewsImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    newsImageup.CopyTo(stream);
                }
                _context.News.Update(news);
                _context.SaveChanges();
            }

        }


        public void DeleteNews(News news)
        {
            string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/news/image", news.NewsImage);
            if (File.Exists(deleteimagePath))
            {
                File.Delete(deleteimagePath);
            }
            _context.Remove(news);
            _context.SaveChanges();
        }


        public Section FindSectionBySectionId(int sectionId)
        {
            return _context.Section.Find(sectionId);
        }

        public int AddSection(Section section)
        {
            _context.Section.Add(section);
            _context.SaveChanges();
            return section.SectionId;
        }

        public void EditSection(Section section)
        {
            _context.Section.Update(section);
            _context.SaveChanges();
        }

        public void DeleteSection(Section section)
        {
            _context.Section.Remove(section);
            _context.SaveChanges();
        }

        public IEnumerable<News> GetSectionNews(int id)
        {
            return _context.News.Include(n=> n.Section).Include(n => n.User).Where(n => n.SectionId== id);
        }

        public IEnumerable<News> GetAuthorNews(string username)
        {
            return _context.News.Include(n => n.User).Include(n => n.Section).Where(n => n.User.UserName == username);
        }

        public IEnumerable<News> GetNewsByFilter(string filterTitle = "")
        {
            IQueryable<News> result = _context.News.Include(n => n.Section).Include(n => n.User);

            if (!string.IsNullOrEmpty(filterTitle))
            {
                result = result.Where(n => n.NewsTitle.Contains(filterTitle));
            }

            return result;
        }

        public void AddComment(CommentViewModel commentViewModel)
        {
            Comments comment = new Comments()
            {
                NewsId= commentViewModel.NewsId,
                UserId = commentViewModel.UserId,
                Comment = commentViewModel.Comment,
                Username=commentViewModel.Username,
                CreateDate = commentViewModel.CreateDate,
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
