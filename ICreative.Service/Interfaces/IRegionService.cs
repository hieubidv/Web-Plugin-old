
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IRegionService
    {
        CreateRegionResponse CreateRegion(CreateRegionRequest request);
        GetRegionResponse GetRegion(GetRegionRequest request);
        GetAllRegionResponse GetAllRegions();
        ModifyRegionResponse ModifyRegion(ModifyRegionRequest request);
        RemoveRegionResponse RemoveRegion(RemoveRegionRequest request);
    }

}
