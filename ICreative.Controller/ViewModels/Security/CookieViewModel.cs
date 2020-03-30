using ICreative.Controllers.ViewModels.Security;
using ICreative.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class CookieView
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RightView> Permissions { get; set; }
    }
}
