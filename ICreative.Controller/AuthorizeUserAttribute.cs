
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;

namespace ICreative.Controllers.ViewModels
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            var right = PermissionLoader.Rights.Where(u => u.ActionName == filterContext.ActionDescriptor.ActionName && u.ControllerName == filterContext.ActionDescriptor.ControllerDescriptor.ControllerName).FirstOrDefault();


                if (right != null)
                if (filterContext.HttpContext.Request.IsAuthenticated)
                {

                        if (!CurrentUser.IsHavePermission(new Security.RightView() { ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, ActionName = filterContext.ActionDescriptor.ActionName }))
                        {
                         filterContext.Result = new RedirectToRouteResult(new
                               RouteValueDictionary(new { controller = "Unauthorized", action = "index" }));
                        }


                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Login", action = "index" }));
                }

        }
    }

}
