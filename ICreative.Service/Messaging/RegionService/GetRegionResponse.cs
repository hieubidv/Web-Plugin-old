
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetRegionResponse
    {
              public bool RegionFound { get; set; }
              public RegionView Region { get; set; }
    }
}
