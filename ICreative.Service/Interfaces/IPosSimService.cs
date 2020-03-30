
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPosSimService
    {
        CreatePosSimResponse CreatePosSim(CreatePosSimRequest request);
        GetPosSimResponse GetPosSim(GetPosSimRequest request);
        GetAllPosSimResponse GetAllPosSims();
        ModifyPosSimResponse ModifyPosSim(ModifyPosSimRequest request);
        RemovePosSimResponse RemovePosSim(RemovePosSimRequest request);
    }

}
