
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreateOrderRequest
    {
		public System.DateTime OrderDate { get; set; }  
		public System.DateTime RequiredDate { get; set; }  
		public System.DateTime ShippedDate { get; set; }  
		public System.Decimal Freight { get; set; }  
		public System.String ShipName { get; set; }  
		public System.String ShipAddress { get; set; }  
		public System.String ShipCity { get; set; }  
		public System.String ShipRegion { get; set; }  
		public System.String ShipPostalCode { get; set; }  
		public System.String ShipCountry { get; set; }  
		public IList<ProductView> Products { get; set; }  
		public EmployeeView Employee { get; set; }  
		public CustomerView Customer { get; set; }  
		public ShipperView Shipper { get; set; }  
    }
}
