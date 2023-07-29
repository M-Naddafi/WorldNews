using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldNews.Core.DTOs;
using WorldNews.Core.Services.Interfaces;
using WorldNews.DataLayer.Context;
using WorldNews.DataLayer.Models;

namespace WorldNews.Core.Services
{
    public class AccountService : IAccountService
    {
        #region Context

        private WNewsContext _context;
        public AccountService(WNewsContext context)
        {
            _context = context;
        }


        #endregion

        public bool DoesUsernameExist(string username)
        {
            return _context.User.Any(u => u.UserName == username);
        }

        public User GetUserByUserId(int userId)
        {
            return _context.User.Find(userId);
        }

        public int GetUserIdByUserName(string username)
        {
            return _context.User.Where(u => u.UserName == username).Select(u => u.UserId).FirstOrDefault();
        }

        public User LoginUser(string username, string password)
        {
            return _context.User.SingleOrDefault(u => u.UserName == username && u.Password == password);
        }

        public void RegisterUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public int AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public void EditUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.User.Remove(user);
            _context.SaveChanges();
        }
        public UserPanelViewModel GetUsersForUserPanel(int pageId, string filterUsername = "")
        {
            IQueryable<User> result = _context.User;

            if (!string.IsNullOrEmpty(filterUsername))
            {
                result = result.Where(u => u.UserName.Contains(filterUsername));
            }

            // Show Item In Page
            int take = 20;
            int skip = (pageId - 1) * take;


            UserPanelViewModel list = new UserPanelViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.UserName).Skip(skip).Take(take).ToList();

            return list;
        }

    }
}
