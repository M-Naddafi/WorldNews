using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldNews.Core.DTOs;
using WorldNews.DataLayer.Models;

namespace WorldNews.Core.Services.Interfaces
{
    public interface IAccountService
    {
        bool DoesUsernameExist(string username);
        void RegisterUser(User user);
        User LoginUser(string username, string password);
        int GetUserIdByUserName(string username);
        UserPanelViewModel GetUsersForUserPanel(int pageId, string filterUsername = "");
        User GetUserByUserId(int userId);
        int AddUser(User user);
        void EditUser(User user); 
        void DeleteUser(User user);
    }
}
