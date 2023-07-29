using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldNews.DataLayer.Models
{
    public class Comments
    {
        public Comments()
        {

        }


        [Key]
        public int CommentId { get; set; }


        public int NewsId { get; set; }


        public int UserId { get; set; }


        public string Username { get; set; }


        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Please eneter {0}")]
        [MaxLength(1000, ErrorMessage = "{0} can't be more than {1} characters")]
        public string Comment { get; set; }


        public DateTime CreateDate { get; set; }


        #region Relatins


        public virtual News News { get; set; }


        #endregion


    }
}
