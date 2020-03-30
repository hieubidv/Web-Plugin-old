
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetCustomerResponse
    {
              public bool CustomerFound { get; set; }
              public CustomerView Customer { get; set; }
    }
}
