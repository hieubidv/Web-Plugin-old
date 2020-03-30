using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICreative.Controllers.ViewModels.Security;
using ICreative.Services.Implementations;
using ICreative.Services.Interfaces;
using ICreative.Services.ViewModels;

namespace ICreative.Controllers
{
    public static class PermissionLoader
    {
        private static List<RightView> _rights;

        public  static List<RightView> Rights {
            get {
            return _rights;
                }

        }

        public static void LoadRights(IPermissionService permissionService)
        {
            IEnumerable<PermissionView> permissions = permissionService.GetAllPermissions().Permissions;
            _rights = new List<RightView>();
            foreach (PermissionView permission in permissions)
            {
                Rights.Add(new RightView() { ControllerName = permission.ControllerName, ActionName = permission.ActionName });
            }
        }
    }
}
