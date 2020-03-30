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
    public class RoleDetailController : Controller
    {
        private IRoleService _roleService;    
               
        public RoleDetailController(IRoleService roleService)
        {
             _roleService = roleService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/RoleDetail", id);
        }

        public JsonResult GetRole(System.Int32 id)
        {
            DataTableViewModel data1;

            GetRoleRequest request = new GetRoleRequest();
            request.RoleId = id;
            DetailRole_RoleDetailView data = _roleService.GetRole(request).Role.ConvertToDetailRole_RoleDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPermissionDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetRoleRequest request = new GetRoleRequest();
            request.RoleId = id;
            RoleView role = _roleService.GetRole(request).Role;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = role.Permissions.ToList().Count.ToString();
            data.recordsFiltered = role.Permissions.ToList().Count.ToString();

            data.data = role.Permissions.ConvertToDetailRolePermissionDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUserDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetRoleRequest request = new GetRoleRequest();
            request.RoleId = id;
            RoleView role = _roleService.GetRole(request).Role;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = role.Users.ToList().Count.ToString();
            data.recordsFiltered = role.Users.ToList().Count.ToString();

            data.data = role.Users.ConvertToDetailRoleUserDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
