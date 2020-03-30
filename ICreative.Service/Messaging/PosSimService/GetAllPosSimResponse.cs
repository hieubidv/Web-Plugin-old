
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllPosSimResponse
    {
              public bool PosSimFound { get; set; }
              public IEnumerable<PosSimView> PosSims { get; set; }
    }
}
