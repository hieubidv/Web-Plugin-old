
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreateCustomerDemographicRequest
    {
		public System.String CustomerDesc { get; set; }  
		public IList<CustomerView> Customers { get; set; }  
    }
}
