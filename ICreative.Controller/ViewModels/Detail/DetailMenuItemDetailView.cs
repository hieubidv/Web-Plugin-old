using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  	
namespace ICreative.Controllers.ViewModels
{

    public class DetailMenuItem_MenuItemDetailView
    {
        public System.Int32 MenuItemId { get; set; }
        public System.String MenuItemName { get; set; }
        public System.Int32 ParentId { get; set; }
        public System.String MenuItemUrl { get; set; }
    }

}
