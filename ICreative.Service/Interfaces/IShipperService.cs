
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IShipperService
    {
        CreateShipperResponse CreateShipper(CreateShipperRequest request);
        GetShipperResponse GetShipper(GetShipperRequest request);
        GetAllShipperResponse GetAllShippers();
        ModifyShipperResponse ModifyShipper(ModifyShipperRequest request);
        RemoveShipperResponse RemoveShipper(RemoveShipperRequest request);
    }

}
