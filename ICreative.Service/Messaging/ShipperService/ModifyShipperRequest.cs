
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyShipperRequest
    {

        public System.Int32 ShipperID  { get; set; }  
		public System.String CompanyName { get; set; }  
		public System.String Phone { get; set; }  
		public IList<OrderView> Orders { get; set; }  
       
    }
}
