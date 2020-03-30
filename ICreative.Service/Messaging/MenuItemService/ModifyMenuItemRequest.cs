
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyMenuItemRequest
    {

        public System.Int32 MenuItemId  { get; set; }  
		public System.String MenuItemName { get; set; }  
		public System.Int32 ParentId { get; set; }  
		public System.String MenuItemUrl { get; set; }  
       
    }
}
