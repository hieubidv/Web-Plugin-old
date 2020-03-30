
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class SupplierView
    {
        public System.Int32 SupplierID  { get ; set; }  
		public System.String CompanyName { get; set; }  
		public System.String ContactName { get; set; }  
		public System.String ContactTitle { get; set; }  
		public System.String Address { get; set; }  
		public System.String City { get; set; }  
		public System.String Region { get; set; }  
		public System.String PostalCode { get; set; }  
		public System.String Country { get; set; }  
		public System.String Phone { get; set; }  
		public System.String Fax { get; set; }  
		public System.String HomePage { get; set; }  
		public IList<ProductView> Products { get; set; }  
    }
}


