﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetPosTerminalResponse
    {
              public bool PosTerminalFound { get; set; }
              public PosTerminalView PosTerminal { get; set; }
    }
}
