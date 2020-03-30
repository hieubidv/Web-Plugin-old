using ICreative.Controllers.ViewModels.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class CustomPrincipalSerializeModel : IPrincipalSerializeModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RightView> Permissions { get; set; }
    }
}
