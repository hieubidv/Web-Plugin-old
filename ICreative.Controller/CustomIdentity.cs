using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string name,bool isAuthenticated)
        {
            Name = name;
            IsAuthenticated = isAuthenticated;
        }

        public string Name { get; set; }

        public string AuthenticationType { get { return "Custom"; } }

        public bool IsAuthenticated { get; set; }
    }
}
