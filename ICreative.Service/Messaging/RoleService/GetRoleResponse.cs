
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetRoleResponse
    {
              public bool RoleFound { get; set; }
              public RoleView Role { get; set; }
    }
}
