
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyCustomerDemographicRequest
    {

        public System.String CustomerTypeID  { get; set; }  
		public System.String CustomerDesc { get; set; }  
		public IList<CustomerView> Customers { get; set; }  
       
    }
}
