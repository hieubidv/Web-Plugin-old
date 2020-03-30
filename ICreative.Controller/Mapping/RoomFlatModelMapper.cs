using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using ICreative.Controllers.ViewModels;
using ICreative.Services.Messaging;
using AutoMapper;
namespace ICreative.Controllers.Mapping
{
    public static class RoomFlatViewModelMapper
    {
        public static RoomFlatViewModel ConvertToRoomFlatViewModel(
                                               this RoomView room)
        {
            return Mapper.Map<RoomView,
                              RoomFlatViewModel>(room);
        }
        
        
        public static IEnumerable<RoomFlatViewModel> ConvertToRoomFlatViewModels(
                                                      this IEnumerable<RoomView> rooms)
        {
            return Mapper.Map<IEnumerable<RoomView>, IEnumerable<RoomFlatViewModel>>(rooms);
        }               

        public static RoomDetailView ConvertToRoomDetailView(
                                               this RoomView room)
        {
            return Mapper.Map<RoomView,
                              RoomDetailView>(room);
        }
        
        
        public static IEnumerable<RoomDetailView> ConvertToRoomDetailViews(
                                                      this IEnumerable<RoomView> rooms)
        {
            return Mapper.Map<IEnumerable<RoomView>, IEnumerable<RoomDetailView>>(rooms);
        }

        public static ModifyRoomRequest ConvertToModifyRoomRequest(
                                               this RoomView rooms)
        {
            return Mapper.Map<RoomView,
                              ModifyRoomRequest>(rooms);
        }    	

        public static DetailRoom_RoomDetailView ConvertToDetailRoom_RoomDetailView(
                                       this RoomView rooms)
        {
            return Mapper.Map<RoomView,
                              DetailRoom_RoomDetailView>(rooms);
        }

        public static IEnumerable<DetailRoom_UserDetailView> ConvertToDetailRoomUserDetailViews(
                                              this IEnumerable<UserView> users)
        {
            return Mapper.Map<IEnumerable<UserView>, IEnumerable<DetailRoom_UserDetailView>>(users);
        }    	

    }

}
