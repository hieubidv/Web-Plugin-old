
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class ShipperView
    {
        public System.Int32 ShipperID  { get ; set; }  
		public System.String CompanyName { get; set; }  
		public System.String Phone { get; set; }  
		public IList<OrderView> Orders { get; set; }  
    }
}


