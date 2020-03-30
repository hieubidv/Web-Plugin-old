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
    public class PermissionTableController : Controller
    {

        private IPermissionService _permissionService;    
               
        public PermissionTableController(IPermissionService permissionService)
        {
             _permissionService = permissionService;
        }
 
        public ActionResult Index()
        {
            PermissionTableViewModel model = new PermissionTableViewModel();
            return View("../Datatables/PermissionTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PermissionFlatViewModel> permissions;
            permissions = _permissionService.GetAllPermissions().Permissions.ConvertToPermissionFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = permissions.ToList().Count.ToString();
            data.recordsFiltered = permissions.ToList().Count.ToString();

            data.data = permissions.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PermissionDetailView vm = new PermissionDetailView();
            GetPermissionRequest request = new GetPermissionRequest();
            request.PermissionId = id;
            GetPermissionResponse response = _permissionService.GetPermission(request);
            if (response.PermissionFound)
                vm = response.Permission.ConvertToPermissionDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PermissionDetailView vm)
        {
            GetPermissionRequest request = new GetPermissionRequest();
            request.PermissionId = vm.PermissionId;
           
            ModifyPermissionRequest updateRequest = _permissionService.GetPermission(request).Permission.ConvertToModifyPermissionRequest();

            updateRequest.PermissionId = vm.PermissionId;
            updateRequest.PermissionName = vm.PermissionName;
            updateRequest.PermissionDescription = vm.PermissionDescription;
            updateRequest.ControllerName = vm.ControllerName;
            updateRequest.ActionName = vm.ActionName;
            updateRequest.IsAnonymous = vm.IsAnonymous;
            updateRequest.IsDefaultAllow = vm.IsDefaultAllow;

            ModifyPermissionResponse response = _permissionService.ModifyPermission(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PermissionDetailView vm)
        {
            CreatePermissionRequest request = new CreatePermissionRequest();
            request.PermissionName = vm.PermissionName;
            request.PermissionDescription = vm.PermissionDescription;
            request.ControllerName = vm.ControllerName;
            request.ActionName = vm.ActionName;
            request.IsAnonymous = vm.IsAnonymous;
            request.IsDefaultAllow = vm.IsDefaultAllow;
            CreatePermissionResponse response = _permissionService.CreatePermission(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePermissionRequest request = new RemovePermissionRequest();
            request.PermissionId = id;
            RemovePermissionResponse response = _permissionService.RemovePermission(request);
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

              //                  CreatePermissionRequest request = new CreatePermissionRequest();
             //                   request.PermissionId = csvReader[0];
             //                   request.PermissionName = csvReader[0];
             //                   request.PermissionDescription = csvReader[0];
             //                   request.ControllerName = csvReader[0];
             //                   request.ActionName = csvReader[0];
             //                   request.IsAnonymous = csvReader[0];
             //                   request.IsDefaultAllow = csvReader[0];
             //                 CreatePermissionResponse response = _permissionService.CreatePermission(request);

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
