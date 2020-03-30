
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetPosDeviceResponse
    {
              public bool PosDeviceFound { get; set; }
              public PosDeviceView PosDevice { get; set; }
    }
}
