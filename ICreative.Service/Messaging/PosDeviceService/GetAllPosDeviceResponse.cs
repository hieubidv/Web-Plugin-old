
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllPosDeviceResponse
    {
              public bool PosDeviceFound { get; set; }
              public IEnumerable<PosDeviceView> PosDevices { get; set; }
    }
}
