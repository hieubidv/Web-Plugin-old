
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetMenuItemResponse
    {
              public bool MenuItemFound { get; set; }
              public MenuItemView MenuItem { get; set; }
    }
}
