using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Principal;
using ICreative.Controllers.ViewModels.Security;
namespace ICreative.Controllers
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(string username,bool isAuthenticate)
        {
            Identity = new CustomIdentity(username,isAuthenticate); 
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public List<RightView> Permissions { get; set; }
        public IIdentity Identity { get; private set; }

        public bool IsHavePermission(RightView permission)
        {
            if (Permissions.Any(r => (permission.ControllerName == r.ControllerName) && (permission.ActionName == r.ActionName)))
            {
                return true;
            }
            return false;
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
