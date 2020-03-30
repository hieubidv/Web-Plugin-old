
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreateProductRequest
    {
		public System.String ProductName { get; set; }  
		public System.String QuantityPerUnit { get; set; }  
		public System.Decimal UnitPrice { get; set; }  
		public System.Int16 UnitsInStock { get; set; }  
		public System.Int16 UnitsOnOrder { get; set; }  
		public System.Int16 ReorderLevel { get; set; }  
		public System.Boolean Discontinued { get; set; }  
		public IList<OrderView> Orders { get; set; }  
		public CategoryView Category { get; set; }  
		public SupplierView Supplier { get; set; }  
    }
}
