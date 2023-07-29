using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;
using WorldNews.Core.DTOs;
using WorldNews.Core.Services.Interfaces;

namespace WorldNews.Pages.UserPanel
{
    public class IndexModel : PageModel
    {
        #region Services


        private IAccountService _accountService;
        public IndexModel(IAccountService accountService)
        {
            _accountService= accountService;
        }


        #endregion


        public UserPanelViewModel users { get; set; }

        public void OnGet(int pageId = 1, string filterUsername = "")
        {
            users = _accountService.GetUsersForUserPanel(pageId,filterUsername);
        }
    }
}
