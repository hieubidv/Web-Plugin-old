
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllUserResponse
    {
              public bool UserFound { get; set; }
              public IEnumerable<UserView> Users { get; set; }
    }
}
