
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllPosSimProviderResponse
    {
              public bool PosSimProviderFound { get; set; }
              public IEnumerable<PosSimProviderView> PosSimProviders { get; set; }
    }
}
