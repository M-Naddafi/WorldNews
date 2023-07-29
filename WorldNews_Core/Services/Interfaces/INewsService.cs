using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WorldNews.Core.DTOs;
using WorldNews.DataLayer.Models;

namespace WorldNews.Core.Services.Interfaces
{
    public interface INewsService
    {
        News FindNewsById(int newsId);
        IEnumerable<Section> GetAllSections();
        NewsPanelViewModel GetNewsForNewsPanel(int pageId = 1, string filterTitle = "", string filterSection = "");
        int AddNews(News news, IFormFile newsImage);
        void EditNews(News news, IFormFile newsImage);
        void DeleteNews(News news);
        Section FindSectionBySectionId(int sectionId);
        int AddSection(Section section);
        void EditSection(Section section);
        void DeleteSection(Section section);
        IEnumerable<News> GetSectionNews(int id);
        IEnumerable<News> GetAuthorNews(string username);
        IEnumerable<News> GetNewsByFilter(string filterTitle = "");
        void AddComment(CommentViewModel commentViewModel);
    }
}
