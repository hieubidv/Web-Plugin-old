
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Infrastructure.Menu;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public partial class MenuItemView : IMenuItem
    {
        public System.Int32 MenuItemId  { get ; set; }  
		public System.String MenuItemName { get; set; }  
		public System.Int32 ParentId { get; set; }  
		public System.String MenuItemUrl { get; set; }  
    }
}


