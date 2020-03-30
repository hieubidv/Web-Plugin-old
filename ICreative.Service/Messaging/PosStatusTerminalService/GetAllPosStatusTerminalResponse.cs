
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllPosStatusTerminalResponse
    {
              public bool PosStatusTerminalFound { get; set; }
              public IEnumerable<PosStatusTerminalView> PosStatusTerminals { get; set; }
    }
}
