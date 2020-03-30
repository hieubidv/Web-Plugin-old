using System;
using System.Web.Mvc;
using System.Linq;
using ICreative.Services.Interfaces;
using ICreative.Services.ViewModels;
using ICreative.Controllers.ViewModels;
using System.Collections.Generic;
using ICreative.Controllers.Mapping;
using ICreative.Controllers.Datatables;
using ICreative.Services.Messaging;
using ICreative.Controllers.ViewModels.Datatable;
using System.Web;
using System.IO;
namespace ICreative.Controllers.Controllers
{
    public class RoomTableController : Controller
    {

        private IRoomService _roomService;    
               
        public RoomTableController(IRoomService roomService)
        {
             _roomService = roomService;
        }
 
        public ActionResult Index()
        {
            RoomTableViewModel model = new RoomTableViewModel();
            return View("../Datatables/RoomTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<RoomFlatViewModel> rooms;
            rooms = _roomService.GetAllRooms().Rooms.ConvertToRoomFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = rooms.ToList().Count.ToString();
            data.recordsFiltered = rooms.ToList().Count.ToString();

            data.data = rooms.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            RoomDetailView vm = new RoomDetailView();
            GetRoomRequest request = new GetRoomRequest();
            request.RoomId = id;
            GetRoomResponse response = _roomService.GetRoom(request);
            if (response.RoomFound)
                vm = response.Room.ConvertToRoomDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(RoomDetailView vm)
        {
            GetRoomRequest request = new GetRoomRequest();
            request.RoomId = vm.RoomId;
           
            ModifyRoomRequest updateRequest = _roomService.GetRoom(request).Room.ConvertToModifyRoomRequest();

            updateRequest.RoomId = vm.RoomId;
            updateRequest.RoomName = vm.RoomName;
            updateRequest.Address = vm.Address;
            updateRequest.PhoneNumber = vm.PhoneNumber;

            ModifyRoomResponse response = _roomService.ModifyRoom(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(RoomDetailView vm)
        {
            CreateRoomRequest request = new CreateRoomRequest();
            request.RoomName = vm.RoomName;
            request.Address = vm.Address;
            request.PhoneNumber = vm.PhoneNumber;
            CreateRoomResponse response = _roomService.CreateRoom(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveRoomRequest request = new RemoveRoomRequest();
            request.RoomId = id;
            RemoveRoomResponse response = _roomService.RemoveRoom(request);
            return Json(response);
        }
        
        
        
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase uploadedFile)
        {
            try
            {
                if (uploadedFile.ContentLength > 0)
                {
                    if (uploadedFile.FileName.EndsWith(".csv"))
                    {
                        Stream stream = uploadedFile.InputStream;
              //          using (CsvReader csvReader =
              //              new CsvReader(new StreamReader(stream), true))
              //          {
              //              while (csvReader.ReadNextRecord())
              //              {

              //                  CreateRoomRequest request = new CreateRoomRequest();
             //                   request.RoomId = csvReader[0];
             //                   request.RoomName = csvReader[0];
             //                   request.Address = csvReader[0];
             //                   request.PhoneNumber = csvReader[0];
             //                 CreateRoomResponse response = _roomService.CreateRoom(request);

             //               }
             //           }                     
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");                     
                    }
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }        
        
    }
}
