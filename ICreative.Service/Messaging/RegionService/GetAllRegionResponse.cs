
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllRegionResponse
    {
              public bool RegionFound { get; set; }
              public IEnumerable<RegionView> Regions { get; set; }
    }
}
