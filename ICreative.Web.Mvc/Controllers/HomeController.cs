using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICreative.Web.Mvc.Controllers
{

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            RedirectToAction("Index", "UserTable");
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Wizard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}
