using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Models;

namespace WorldNews.Pages.UserPanel
{
    public class AddUserModel : PageModel
    {
        #region Services


        private IAccountService _accountService;
        public AddUserModel(IAccountService accountService)
        {
            _accountService = accountService;
        }


        #endregion

        [BindProperty]
        public User user { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
           _accountService.AddUser(user);
           
           return RedirectToPage("Index");
        }
    }
}
