
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetPosSimProviderResponse
    {
              public bool PosSimProviderFound { get; set; }
              public PosSimProviderView PosSimProvider { get; set; }
    }
}
