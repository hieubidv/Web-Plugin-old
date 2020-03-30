
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllRoomResponse
    {
              public bool RoomFound { get; set; }
              public IEnumerable<RoomView> Rooms { get; set; }
    }
}
