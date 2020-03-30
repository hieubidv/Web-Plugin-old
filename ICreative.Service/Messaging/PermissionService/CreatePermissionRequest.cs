
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreatePermissionRequest
    {
		public System.String PermissionName { get; set; }  
		public System.String PermissionDescription { get; set; }  
		public System.String ControllerName { get; set; }  
		public System.String ActionName { get; set; }  
		public System.Boolean IsAnonymous { get; set; }  
		public System.Boolean IsDefaultAllow { get; set; }  
		public IList<RoleView> Roles { get; set; }  
		public IList<UserView> Users { get; set; }  
    }
}
