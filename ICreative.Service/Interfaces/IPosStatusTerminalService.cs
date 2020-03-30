
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPosStatusTerminalService
    {
        CreatePosStatusTerminalResponse CreatePosStatusTerminal(CreatePosStatusTerminalRequest request);
        GetPosStatusTerminalResponse GetPosStatusTerminal(GetPosStatusTerminalRequest request);
        GetAllPosStatusTerminalResponse GetAllPosStatusTerminals();
        ModifyPosStatusTerminalResponse ModifyPosStatusTerminal(ModifyPosStatusTerminalRequest request);
        RemovePosStatusTerminalResponse RemovePosStatusTerminal(RemovePosStatusTerminalRequest request);
    }

}
