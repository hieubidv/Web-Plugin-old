
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetCustomerDemographicResponse
    {
              public bool CustomerDemographicFound { get; set; }
              public CustomerDemographicView CustomerDemographic { get; set; }
    }
}
