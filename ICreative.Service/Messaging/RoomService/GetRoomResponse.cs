
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetRoomResponse
    {
              public bool RoomFound { get; set; }
              public RoomView Room { get; set; }
    }
}
