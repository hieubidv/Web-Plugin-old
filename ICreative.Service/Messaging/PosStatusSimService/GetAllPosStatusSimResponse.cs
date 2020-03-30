
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllPosStatusSimResponse
    {
              public bool PosStatusSimFound { get; set; }
              public IEnumerable<PosStatusSimView> PosStatusSims { get; set; }
    }
}
