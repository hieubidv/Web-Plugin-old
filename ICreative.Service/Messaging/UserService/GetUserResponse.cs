
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetUserResponse
    {
              public bool UserFound { get; set; }
              public UserView User { get; set; }
    }
}
