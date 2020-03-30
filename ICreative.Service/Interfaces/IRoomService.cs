
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IRoomService
    {
        CreateRoomResponse CreateRoom(CreateRoomRequest request);
        GetRoomResponse GetRoom(GetRoomRequest request);
        GetAllRoomResponse GetAllRooms();
        ModifyRoomResponse ModifyRoom(ModifyRoomRequest request);
        RemoveRoomResponse RemoveRoom(RemoveRoomRequest request);
    }

}
