
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPermissionService
    {
        CreatePermissionResponse CreatePermission(CreatePermissionRequest request);
        GetPermissionResponse GetPermission(GetPermissionRequest request);
        GetAllPermissionResponse GetAllPermissions();
        ModifyPermissionResponse ModifyPermission(ModifyPermissionRequest request);
        RemovePermissionResponse RemovePermission(RemovePermissionRequest request);
    }

}
