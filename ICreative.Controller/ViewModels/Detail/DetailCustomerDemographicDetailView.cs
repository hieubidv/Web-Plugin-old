using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  	
namespace ICreative.Controllers.ViewModels
{

    public class DetailCustomerDemographic_CustomerDemographicDetailView
    {
        public System.String CustomerTypeID { get; set; }
        public System.String CustomerDesc { get; set; }
    }

    public class DetailCustomerDemographic_CustomerDetailView
    {
        public System.String CustomerID { get; set; }
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
    }
}
