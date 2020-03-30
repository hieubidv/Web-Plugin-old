
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetOrderResponse
    {
              public bool OrderFound { get; set; }
              public OrderView Order { get; set; }
    }
}
