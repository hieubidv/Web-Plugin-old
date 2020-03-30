
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllPermissionResponse
    {
              public bool PermissionFound { get; set; }
              public IEnumerable<PermissionView> Permissions { get; set; }
    }
}
