using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using SeaBattle.Data.Context;
using SeaBattle.Data.Model;
using SeaBattle.Service.Base;

namespace SeaBattle.Service
{
    public class UserService: ServiceBase
    {
        public UserService(SeaBattleContext context) : base(context)
        {
        }

        public (UserAccount, User) AddUser(string email, string login, string fname, string lname, string pass)
        {
            var account = new UserAccount();
            account.Email = email;
            var salt = Crypto.GenerateSalt();

            account.Salt = salt;
            account.HashPassword = Crypto.HashPassword(pass + salt);
            _dbContext.UserAccounts.Add(account);
            Save();

            UnitOfWork.UnitOfWork.Instance.EmailService.SendVerifyMessage(account);

            var user = new User();
            user.FirstName = fname;
            user.Login = login;
            user.LastName = lname;
            user.UserAccountId = account.Id;

            _dbContext.Users.Add(user);
            Save();

            return (account, user);
        }
    }
}
