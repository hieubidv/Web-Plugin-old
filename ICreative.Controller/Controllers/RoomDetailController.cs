using ICreative.Controllers.Datatables;
using ICreative.Controllers.Mapping;
using ICreative.Controllers.ViewModels;
using ICreative.Services.Interfaces;
using ICreative.Services.Messaging;
using ICreative.Services.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ICreative.Controllers.Controllers
{
    public class RoomDetailController : Controller
    {
        private IRoomService _roomService;    
               
        public RoomDetailController(IRoomService roomService)
        {
             _roomService = roomService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/RoomDetail", id);
        }

        public JsonResult GetRoom(System.Int32 id)
        {
            DataTableViewModel data1;

            GetRoomRequest request = new GetRoomRequest();
            request.RoomId = id;
            DetailRoom_RoomDetailView data = _roomService.GetRoom(request).Room.ConvertToDetailRoom_RoomDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetUserDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetRoomRequest request = new GetRoomRequest();
            request.RoomId = id;
            RoomView room = _roomService.GetRoom(request).Room;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = room.Users.ToList().Count.ToString();
            data.recordsFiltered = room.Users.ToList().Count.ToString();

            data.data = room.Users.ConvertToDetailRoomUserDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
