
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetPosAddressResponse
    {
              public bool PosAddressFound { get; set; }
              public PosAddressView PosAddress { get; set; }
    }
}
