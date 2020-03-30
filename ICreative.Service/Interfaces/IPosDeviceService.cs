
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPosDeviceService
    {
        CreatePosDeviceResponse CreatePosDevice(CreatePosDeviceRequest request);
        GetPosDeviceResponse GetPosDevice(GetPosDeviceRequest request);
        GetAllPosDeviceResponse GetAllPosDevices();
        ModifyPosDeviceResponse ModifyPosDevice(ModifyPosDeviceRequest request);
        RemovePosDeviceResponse RemovePosDevice(RemovePosDeviceRequest request);
    }

}
