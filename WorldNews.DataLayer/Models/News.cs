using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldNews.DataLayer.Models
{
    public class News
    {
        public News()
        {

        }

        [Key]
        public int NewsId { get; set; }


        [Display(Name = "Section")]
        [Required(ErrorMessage = "Please eneter {0}")]
        public int SectionId { get; set; }


        public int UserId { get; set; }


        [Display(Name = "NewsTitle")]
        [Required(ErrorMessage = "Please eneter {0}")]
        [MaxLength(500, ErrorMessage = "{0} can't be more than {1} characters")]
        public string NewsTitle { get; set; }


        [Display(Name = "News Content")]
        [Required(ErrorMessage = "Please eneter {0}")]
        [MaxLength(10000, ErrorMessage = "{0} can't be more than {1} characters")]
        public string NewsDescription { get; set; }


        [Display(Name = "Breaking News")]
        public bool BreakingNews { get; set; }


        [Display(Name = "Highligh News")]
        public bool HighlightNews { get; set; }


        public DateTime CreateDate { get; set; }


        [Display(Name = "News Image")]
        [Required(ErrorMessage = "Please eneter {0}")]
        [MaxLength(100, ErrorMessage = "{0} can't be more than {1} characters")]
        public string NewsImage { get; set; }


        #region Relations


        public virtual Section Section { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comments> Comments { get; set; }


        #endregion

    }
}
