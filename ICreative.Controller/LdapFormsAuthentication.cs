using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using ICreative.Infrastructure.Authentication;
using ICreative.Services.Interfaces;
using ICreative.Services.ViewModels;
using System.Web.Security;
using System.Web;

namespace ICreative.Controllers
{
    public class LdapFormsAuthentication : IFormsAuthentication
    {
        private string _filterAttribute;
        private string _path;
        private IUserService _userService;
        public LdapFormsAuthentication(IUserService userService)
        {
            _path = "LDAP://bidvbank.bidv.com/OU=Users,OU=YenBai,OU=MienBac,DC=BIDVBANK,DC=bidv,DC=com";
            _userService = userService;
        }

        public bool Authenticate(string username, string password)
        {
            string domainAndUsername = "bidvbank" + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, password);
            object obj = entry.NativeObject;

            DirectorySearcher search = new DirectorySearcher(entry);

            search.Filter = "(sAMAccountName=" + username + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();

            if (null == result)
            {
                return false;
            }

            _path = result.Path;
            _filterAttribute = (string)result.Properties["cn"][0];

            //   if (username  == "hieupm" & password =="123")
            //      return true;

            IEnumerable<UserView> users = _userService.GetAllUsers().Users;
            UserView user = users.Where(u => u.UserName == username).FirstOrDefault();
            //if (username == "hieupm" & password == "123")
            //    return true;
            if (user == null)
                return false;

            return true;
        }

        public void SetAuthenticationToken(string username, string userData, bool isCookiePersistent)
        {
            var authTicket = new FormsAuthenticationTicket(1,
                username, DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, userData);

            //Encrypt the ticket.
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            //Create a cookie, and then add the encrypted ticket to the cookie as data.
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            if (isCookiePersistent)
                authCookie.Expires = authTicket.Expiration;

            //Add the cookie to the outgoing cookies collection.
            HttpContext.Current.Response.Cookies.Add(authCookie);

            //You can redirect now.
        }
    }

}
