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
    public class UserDetailController : Controller
    {
        private IRoomService _roomService;
private IUserService _userService;    
               
        public UserDetailController(IRoomService roomService,IUserService userService)
        {
             _roomService = roomService;
_userService = userService;
        }
        
                
 
        public ActionResult Detail(System.Guid id)
        {
            return View("../Details/UserDetail", id);
        }

        public JsonResult GetUser(System.Guid id)
        {
            DataTableViewModel data1;

            GetUserRequest request = new GetUserRequest();
            request.UserId = id;
            DetailUser_UserDetailView data = _userService.GetUser(request).User.ConvertToDetailUser_UserDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetRoleDataTable(System.Guid id)
        {
            DataTableViewModel data;

            GetUserRequest request = new GetUserRequest();
            request.UserId = id;
            UserView user = _userService.GetUser(request).User;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = user.Roles.ToList().Count.ToString();
            data.recordsFiltered = user.Roles.ToList().Count.ToString();

            data.data = user.Roles.ConvertToDetailUserRoleDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPermissionDataTable(System.Guid id)
        {
            DataTableViewModel data;

            GetUserRequest request = new GetUserRequest();
            request.UserId = id;
            UserView user = _userService.GetUser(request).User;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = user.Permissions.ToList().Count.ToString();
            data.recordsFiltered = user.Permissions.ToList().Count.ToString();

            data.data = user.Permissions.ConvertToDetailUserPermissionDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPosReceiptOfDeliveryDataTable(System.Guid id)
        {
            DataTableViewModel data;

            GetUserRequest request = new GetUserRequest();
            request.UserId = id;
            UserView user = _userService.GetUser(request).User;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = user.PosReceiptOfDeliveries.ToList().Count.ToString();
            data.recordsFiltered = user.PosReceiptOfDeliveries.ToList().Count.ToString();

            data.data = user.PosReceiptOfDeliveries.ConvertToDetailUserPosReceiptOfDeliveryDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
