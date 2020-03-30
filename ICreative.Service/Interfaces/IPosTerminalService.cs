
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPosTerminalService
    {
        CreatePosTerminalResponse CreatePosTerminal(CreatePosTerminalRequest request);
        GetPosTerminalResponse GetPosTerminal(GetPosTerminalRequest request);
        GetAllPosTerminalResponse GetAllPosTerminals();
        ModifyPosTerminalResponse ModifyPosTerminal(ModifyPosTerminalRequest request);
        RemovePosTerminalResponse RemovePosTerminal(RemovePosTerminalRequest request);
    }

}
