
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllMenuItemResponse
    {
              public bool MenuItemFound { get; set; }
              public IEnumerable<MenuItemView> MenuItems { get; set; }
    }
}
