
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllCustomerDemographicResponse
    {
              public bool CustomerDemographicFound { get; set; }
              public IEnumerable<CustomerDemographicView> CustomerDemographics { get; set; }
    }
}
