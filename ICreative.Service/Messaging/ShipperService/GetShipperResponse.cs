
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetShipperResponse
    {
              public bool ShipperFound { get; set; }
              public ShipperView Shipper { get; set; }
    }
}
