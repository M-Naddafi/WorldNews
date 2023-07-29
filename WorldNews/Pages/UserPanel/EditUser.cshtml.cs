using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Models;

namespace WorldNews.Pages.UserPanel
{
    public class EditUserModel : PageModel
    {
        #region Services


        private IAccountService _accountService;
        public EditUserModel(IAccountService accountService)
        {
            _accountService = accountService;
        }


        #endregion


        [BindProperty]
        public User user { get; set; }


        public void OnGet(int id)
        {
            user = _accountService.GetUserByUserId(id);
        }

        public IActionResult OnPost()
        {
            _accountService.EditUser(user);

            return RedirectToPage("Index");
        }
    }
}
