
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class CustomerDemographicView
    {
        public System.String CustomerTypeID  { get ; set; }  
		public System.String CustomerDesc { get; set; }  
		public IList<CustomerView> Customers { get; set; }  
    }
}


