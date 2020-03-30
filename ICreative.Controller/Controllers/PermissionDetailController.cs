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
    public class PermissionDetailController : Controller
    {
        private IPermissionService _permissionService;    
               
        public PermissionDetailController(IPermissionService permissionService)
        {
             _permissionService = permissionService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PermissionDetail", id);
        }

        public JsonResult GetPermission(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPermissionRequest request = new GetPermissionRequest();
            request.PermissionId = id;
            DetailPermission_PermissionDetailView data = _permissionService.GetPermission(request).Permission.ConvertToDetailPermission_PermissionDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetRoleDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPermissionRequest request = new GetPermissionRequest();
            request.PermissionId = id;
            PermissionView permission = _permissionService.GetPermission(request).Permission;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = permission.Roles.ToList().Count.ToString();
            data.recordsFiltered = permission.Roles.ToList().Count.ToString();

            data.data = permission.Roles.ConvertToDetailPermissionRoleDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUserDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPermissionRequest request = new GetPermissionRequest();
            request.PermissionId = id;
            PermissionView permission = _permissionService.GetPermission(request).Permission;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = permission.Users.ToList().Count.ToString();
            data.recordsFiltered = permission.Users.ToList().Count.ToString();

            data.data = permission.Users.ConvertToDetailPermissionUserDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
