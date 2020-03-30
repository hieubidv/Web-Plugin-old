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
    public class RoleTableController : Controller
    {

        private IRoleService _roleService;    
               
        public RoleTableController(IRoleService roleService)
        {
             _roleService = roleService;
        }
 
        public ActionResult Index()
        {
            RoleTableViewModel model = new RoleTableViewModel();
            return View("../Datatables/RoleTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<RoleFlatViewModel> roles;
            roles = _roleService.GetAllRoles().Roles.ConvertToRoleFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = roles.ToList().Count.ToString();
            data.recordsFiltered = roles.ToList().Count.ToString();

            data.data = roles.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            RoleDetailView vm = new RoleDetailView();
            GetRoleRequest request = new GetRoleRequest();
            request.RoleId = id;
            GetRoleResponse response = _roleService.GetRole(request);
            if (response.RoleFound)
                vm = response.Role.ConvertToRoleDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(RoleDetailView vm)
        {
            GetRoleRequest request = new GetRoleRequest();
            request.RoleId = vm.RoleId;
           
            ModifyRoleRequest updateRequest = _roleService.GetRole(request).Role.ConvertToModifyRoleRequest();

            updateRequest.RoleId = vm.RoleId;
            updateRequest.RoleName = vm.RoleName;
            updateRequest.Description = vm.Description;

            ModifyRoleResponse response = _roleService.ModifyRole(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(RoleDetailView vm)
        {
            CreateRoleRequest request = new CreateRoleRequest();
            request.RoleName = vm.RoleName;
            request.Description = vm.Description;
            CreateRoleResponse response = _roleService.CreateRole(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveRoleRequest request = new RemoveRoleRequest();
            request.RoleId = id;
            RemoveRoleResponse response = _roleService.RemoveRole(request);
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

              //                  CreateRoleRequest request = new CreateRoleRequest();
             //                   request.RoleId = csvReader[0];
             //                   request.RoleName = csvReader[0];
             //                   request.Description = csvReader[0];
             //                 CreateRoleResponse response = _roleService.CreateRole(request);

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
