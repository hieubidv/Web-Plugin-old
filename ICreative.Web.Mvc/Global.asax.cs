using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ICreative.Web;
using ICreative.Services;
using ICreative.Services.Interfaces;
using ICreative.Services.ViewModels;
using ICreative.Controllers.ViewModels;
using ICreative.Controllers;
using System.Web.Security;
using Newtonsoft.Json;
using Microsoft.Practices.Unity;
using ICreative.Infrastructure.Configuration;
using Unity.Mvc4;
using ICreative.Menu;

namespace ICreative.Web.Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ModelBinders.Binders.Add(typeof(DateTime), new CustomDateModelBinder());
            ICreative.Services.AutoMapperBootStrapper.ServiceMap();
            ICreative.Controllers.AutoMapperBootStrapper.ControllerMap();
            ICreative.Services.AutoMapperBootStrapper.Init();          
            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(new WebConfigApplicationSettings());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IUnityContainer unity =  Bootstrapper.Initialise();
            GlobalFilters.Filters.Add(new AuthorizeUserAttribute());

             //Clear ViewEngine increase application performance
             ViewEngines.Engines.Clear(); 
             ViewEngines.Engines.Add(new RazorViewEngine());
             
             
           PermissionLoader.LoadRights(unity.Resolve<IPermissionService>());
           // SingletonRestrictionCollection.Restrictions.LoadRestriction(unity.Resolve<IRestrictionService>());
 
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                try
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    var serialize = JsonConvert.DeserializeObject<CookieView>(authTicket.UserData);
                    var newUser = new CustomPrincipal(authTicket.Name,true);
                    newUser.UserId = serialize.UserId;
                    newUser.FirstName = serialize.FirstName;
                    newUser.LastName = serialize.LastName;
                    newUser.Permissions = serialize.Permissions;

                    HttpContext.Current.User = newUser;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            } else
            {
                HttpContext.Current.User = new CustomPrincipal("Guest",false);
            }
        }
    }
}