
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllCustomerResponse
    {
              public bool CustomerFound { get; set; }
              public IEnumerable<CustomerView> Customers { get; set; }
    }
}
