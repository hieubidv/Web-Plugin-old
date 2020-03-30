
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IRoleService
    {
        CreateRoleResponse CreateRole(CreateRoleRequest request);
        GetRoleResponse GetRole(GetRoleRequest request);
        GetAllRoleResponse GetAllRoles();
        ModifyRoleResponse ModifyRole(ModifyRoleRequest request);
        RemoveRoleResponse RemoveRole(RemoveRoleRequest request);
    }

}
