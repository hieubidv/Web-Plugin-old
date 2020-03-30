
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPosStatusSimService
    {
        CreatePosStatusSimResponse CreatePosStatusSim(CreatePosStatusSimRequest request);
        GetPosStatusSimResponse GetPosStatusSim(GetPosStatusSimRequest request);
        GetAllPosStatusSimResponse GetAllPosStatusSims();
        ModifyPosStatusSimResponse ModifyPosStatusSim(ModifyPosStatusSimRequest request);
        RemovePosStatusSimResponse RemovePosStatusSim(RemovePosStatusSimRequest request);
    }

}
