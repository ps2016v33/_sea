using SeaBattle.Data.Context;
using SeaBattle.Data.Model;
using SeaBattle.Service.Base;
using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Helpers;

namespace SeaBattle.Service
{
    public class EmailService: ServiceBase
    {
        public EmailService(SeaBattleContext context) : base(context)
        {
        }

        public void SendVerifyMessage(UserAccount account)
        {
            var smtp = new SmtpClient();

            var guid = Guid.NewGuid();
            account.VerifyCode = guid;
            var hash = Crypto.HashPassword(account.VerifyCode.ToString());
            Save();

            

            var body = $"Verify account: http://localhost:56889/Home/Index/{account.Id}?hash={hash}";
            var from = "ps2016v33@gmail.com";
            var message = new MailMessage(from, account.Email, "Verify", body);

            smtp.Send(message);
        }

        public void Verify(int id, string hash)
        {
            var account = _dbContext.UserAccounts.FirstOrDefault(x => x.Id == id);
            if (account == null)
                return;

            var flag = Crypto.VerifyHashedPassword(hash, account.VerifyCode.ToString());

            account.IsActivated = flag;
            Save();
        }
    }
}
