
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICreative.Infrastructure.Authentication
{
    public interface IFormsAuthentication
    {
       void SetAuthenticationToken(string username,string data,bool isCookiePersistent);
       bool Authenticate(string username, string password);  
    }                

}
