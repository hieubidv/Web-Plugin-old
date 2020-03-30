
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class RoomMapper
    {
        public static RoomView ConvertToRoomView(
                                               this Room room)
        {
            return Mapper.Map<Room,
                              RoomView>(room);
        }
        
        
        public static IEnumerable<RoomView> ConvertToRoomViews(
                                                      this IEnumerable<Room> rooms)
        {
            return Mapper.Map<IEnumerable<Room>, IEnumerable<RoomView>>(rooms);
        }
        
        public static Room ConvertToRoom(
                                               this RoomView roomView)
        {
            return Mapper.Map<RoomView,
                              Room>(roomView);
        }
        
        
        public static IList<Room> ConvertToRooms(
                                                      this IEnumerable<RoomView> roomsView)
        {
            return Mapper.Map<IEnumerable<RoomView>, IList<Room>>(roomsView);
        }        
        
    }

}
