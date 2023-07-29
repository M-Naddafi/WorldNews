using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WorldNews.Core.DTOs
{
    public class RegisterViewModel
    {
        [MaxLength(300)]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$", ErrorMessage = "Password must contains numbers and letters")]
        public string Password { get; set; }
    }

    public class LoginViewModel
    {
        [MaxLength(300)]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please enter {0}")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
