
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreateMenuItemRequest
    {
		public System.String MenuItemName { get; set; }  
		public System.Int32 ParentId { get; set; }  
		public System.String MenuItemUrl { get; set; }  
    }
}
