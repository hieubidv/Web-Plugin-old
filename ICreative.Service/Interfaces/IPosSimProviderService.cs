
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPosSimProviderService
    {
        CreatePosSimProviderResponse CreatePosSimProvider(CreatePosSimProviderRequest request);
        GetPosSimProviderResponse GetPosSimProvider(GetPosSimProviderRequest request);
        GetAllPosSimProviderResponse GetAllPosSimProviders();
        ModifyPosSimProviderResponse ModifyPosSimProvider(ModifyPosSimProviderRequest request);
        RemovePosSimProviderResponse RemovePosSimProvider(RemovePosSimProviderRequest request);
    }

}
