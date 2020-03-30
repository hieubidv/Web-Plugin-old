
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class RoleView
    {
        public System.Int32 RoleId  { get ; set; }  
		public System.String RoleName { get; set; }  
		public System.String Description { get; set; }  
		public IList<PermissionView> Permissions { get; set; }  
		public IList<UserView> Users { get; set; }  
    }
}


