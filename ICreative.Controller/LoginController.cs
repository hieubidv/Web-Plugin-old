using ICreative.Controllers.ViewModels;
using ICreative.Infrastructure.Authentication;
using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace ICreative.Controllers
{

    public class LoginController : Controller
    {
        private readonly ISecurityApplicationService<Guid> _securityApplicationService;


        public LoginController(ISecurityApplicationService<Guid> securityApplicationService)
        {
            _securityApplicationService = securityApplicationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginView view, string returnUrl = "")
        {

            try
            {              
                if (_securityApplicationService == null)
                    throw new Exception("_securityApplicationService is null");
                if (_securityApplicationService.ValidateLogin(view.Email, view.Password))
                {
                    
                    string userData = _securityApplicationService.CreateCookieUserData(view.Email);
                    
                    _securityApplicationService.SetCookie(view.Email, userData, view.IsRememberMe);
                    
                    if (!string.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("", "Incorrect username and/or password");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(view);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Login");
        }
    }
}