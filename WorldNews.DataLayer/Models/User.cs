using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldNews.DataLayer.Models
{
    public class User
    {
        public User()
        {

        }


        [Key]
        public int UserId { get; set; }


        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(100, ErrorMessage = "{0} can't be more than {1} characters")]
        public string UserName { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(100, ErrorMessage = "{0} can't be more than {1} characters")]
        public string Password { get; set; }


        [Display(Name = "Is Admin")]
        public bool IsAdmin { get; set; }


        #region Relations


        public virtual List<News> News { get; set; }


        #endregion
    }
}
