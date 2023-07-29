using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldNews.DataLayer.Models;

namespace WorldNews.Core.DTOs
{
    public class NewsPanelViewModel
    {
        public List<News> News { get; set; }
        public List<Section> Sections { get; set; }     
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class AddorEditNewsViewModel
    {
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public IFormFile NewsImage { get; set; }
        public bool BreakingNews { get; set; }
        public bool HighlightNews { get; set; }
        public int SectionId { get; set; }
    }

    public class CommentViewModel
    {
        public int NewsId { get; set; }


        public int UserId { get; set; }


        public string Username { get; set; }


        [MaxLength(500)]
        public string Comment { get; set; }


        public DateTime CreateDate { get; set; }
    }
}
