using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class PermissionDetailView
    {
        public System.Int32 PermissionId { get; set; }
        public System.String PermissionName { get; set; }
        public System.String PermissionDescription { get; set; }
        public System.String ControllerName { get; set; }
        public System.String ActionName { get; set; }
        public System.Boolean IsAnonymous { get; set; }
        public System.Boolean IsDefaultAllow { get; set; }
    }
}
