
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetPosStatusSimResponse
    {
              public bool PosStatusSimFound { get; set; }
              public PosStatusSimView PosStatusSim { get; set; }
    }
}
