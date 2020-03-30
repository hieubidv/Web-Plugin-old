
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllPosAddressResponse
    {
              public bool PosAddressFound { get; set; }
              public IEnumerable<PosAddressView> PosAddresses { get; set; }
    }
}
