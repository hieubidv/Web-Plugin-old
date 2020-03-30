using ICreative.Infrastructure.Authentication;
using ICreative.Services.Messaging;
using ICreative.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace ICreative.Controllers
{
    public class DBFormAuthentication : IFormsAuthentication
    {
        private IMembershipService _membershipService;
        public DBFormAuthentication(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }
        public bool Authenticate(string username, string password)
        {
            ValidatePasswordRequest request = new ValidatePasswordRequest();
            request.Username = username;
            request.Password = Helper.Hash(password);
            return _membershipService.Validate(request).Result;            
        }

        public void SetAuthenticationToken(string username, string userData, bool isCookiePersistent)
        {
            var authTicket = new FormsAuthenticationTicket(1,
                username, DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, userData);

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            if (isCookiePersistent)
                authCookie.Expires = authTicket.Expiration;
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }
    }
}
