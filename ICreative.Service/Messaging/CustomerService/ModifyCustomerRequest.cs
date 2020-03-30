
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyCustomerRequest
    {

        public System.String CustomerID  { get; set; }  
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
		public IList<CustomerDemographicView> CustomerDemographics { get; set; }  
		public IList<OrderView> Orders { get; set; }  
       
    }
}
