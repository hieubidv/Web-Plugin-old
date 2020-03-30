
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllShipperResponse
    {
              public bool ShipperFound { get; set; }
              public IEnumerable<ShipperView> Shippers { get; set; }
    }
}
