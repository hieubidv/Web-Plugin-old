
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllRoleResponse
    {
              public bool RoleFound { get; set; }
              public IEnumerable<RoleView> Roles { get; set; }
    }
}
