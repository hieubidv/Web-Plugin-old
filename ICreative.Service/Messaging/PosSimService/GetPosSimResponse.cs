﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetPosSimResponse
    {
              public bool PosSimFound { get; set; }
              public PosSimView PosSim { get; set; }
    }
}
