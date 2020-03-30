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
    public class UserTableController : Controller
    {

        private IRoomService _roomService;
private IUserService _userService;    
               
        public UserTableController(IRoomService roomService,IUserService userService)
        {
             _roomService = roomService;
_userService = userService;
        }
 
        public ActionResult Index()
        {
            UserTableViewModel model = new UserTableViewModel();
            model.Rooms = _roomService.GetAllRooms().Rooms.Select(u=>new SelectListItem() { Text = u.RoomName, Value = u.RoomId.ToString()}).ToList();
            return View("../Datatables/UserTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<UserFlatViewModel> users;
            users = _userService.GetAllUsers().Users.ConvertToUserFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = users.ToList().Count.ToString();
            data.recordsFiltered = users.ToList().Count.ToString();

            data.data = users.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Guid id)
        {  
            UserDetailView vm = new UserDetailView();
            GetUserRequest request = new GetUserRequest();
            request.UserId = id;
            GetUserResponse response = _userService.GetUser(request);
            if (response.UserFound)
                vm = response.User.ConvertToUserDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(UserDetailView vm)
        {
            GetUserRequest request = new GetUserRequest();
            request.UserId = vm.UserId;
           
            ModifyUserRequest updateRequest = _userService.GetUser(request).User.ConvertToModifyUserRequest();

            updateRequest.UserId = vm.UserId;
            updateRequest.UserName = vm.UserName;
            updateRequest.Email = vm.Email;
            updateRequest.Password = vm.Password;
            updateRequest.FirstName = vm.FirstName;
            updateRequest.LastName = vm.LastName;
            updateRequest.PhoneNumber = vm.PhoneNumber;
            updateRequest.BirthDay = vm.BirthDay;
            updateRequest.IpAddress = vm.IpAddress;
            updateRequest.Status = vm.Status;
            updateRequest.CreateDate = vm.CreateDate;
               GetRoomRequest roomRequest = new GetRoomRequest();
            roomRequest.RoomId = vm.RoomRoomId;
            updateRequest.Room = _roomService.GetRoom(roomRequest).Room;            

            ModifyUserResponse response = _userService.ModifyUser(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(UserDetailView vm)
        {
            CreateUserRequest request = new CreateUserRequest();
            request.UserName = vm.UserName;
            request.Email = vm.Email;
            request.Password = vm.Password;
            request.FirstName = vm.FirstName;
            request.LastName = vm.LastName;
            request.PhoneNumber = vm.PhoneNumber;
            request.BirthDay = vm.BirthDay;
            request.IpAddress = vm.IpAddress;
            request.Status = vm.Status;
            request.CreateDate = vm.CreateDate;
               GetRoomRequest roomRequest = new GetRoomRequest();
            roomRequest.RoomId = vm.RoomRoomId;
            request.Room = _roomService.GetRoom(roomRequest).Room;            
            CreateUserResponse response = _userService.CreateUser(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Guid id)
        {
            RemoveUserRequest request = new RemoveUserRequest();
            request.UserId = id;
            RemoveUserResponse response = _userService.RemoveUser(request);
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

              //                  CreateUserRequest request = new CreateUserRequest();
             //                   request.UserId = csvReader[0];
             //                   request.UserName = csvReader[0];
             //                   request.Email = csvReader[0];
             //                   request.Password = csvReader[0];
             //                   request.FirstName = csvReader[0];
             //                   request.LastName = csvReader[0];
             //                   request.PhoneNumber = csvReader[0];
             //                   request.BirthDay = csvReader[0];
             //                   request.IpAddress = csvReader[0];
             //                   request.Status = csvReader[0];
             //                   request.CreateDate = csvReader[0];
             //                   request.RoomRoomId = csvReader[0];
             //                 CreateUserResponse response = _userService.CreateUser(request);

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
