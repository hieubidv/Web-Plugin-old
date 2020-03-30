
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetPosStatusTerminalResponse
    {
              public bool PosStatusTerminalFound { get; set; }
              public PosStatusTerminalView PosStatusTerminal { get; set; }
    }
}
