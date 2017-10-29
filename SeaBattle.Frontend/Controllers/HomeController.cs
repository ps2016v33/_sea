using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeaBattle.Service.UnitOfWork;

namespace SeaBattle.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int id, string hash)
        {
            UnitOfWork.Instance.EmailService.Verify(id, hash);
            return View();
        }
    }
}