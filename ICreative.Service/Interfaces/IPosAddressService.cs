
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPosAddressService
    {
        CreatePosAddressResponse CreatePosAddress(CreatePosAddressRequest request);
        GetPosAddressResponse GetPosAddress(GetPosAddressRequest request);
        GetAllPosAddressResponse GetAllPosAddresses();
        ModifyPosAddressResponse ModifyPosAddress(ModifyPosAddressRequest request);
        RemovePosAddressResponse RemovePosAddress(RemovePosAddressRequest request);
    }

}
