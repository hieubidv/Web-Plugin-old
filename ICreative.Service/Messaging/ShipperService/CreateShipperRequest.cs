
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreateShipperRequest
    {
		public System.String CompanyName { get; set; }  
		public System.String Phone { get; set; }  
		public IList<OrderView> Orders { get; set; }  
    }
}
