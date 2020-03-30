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
    public class RestrictionTableController : Controller
    {

        private IRestrictionService _restrictionService;    
               
        public RestrictionTableController(IRestrictionService restrictionService)
        {
             _restrictionService = restrictionService;
        }
 
        public ActionResult Index()
        {
            RestrictionTableViewModel model = new RestrictionTableViewModel();
            return View("../Datatables/RestrictionTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<RestrictionFlatViewModel> restrictions;
            restrictions = _restrictionService.GetAllRestrictions().Restrictions.ConvertToRestrictionFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = restrictions.ToList().Count.ToString();
            data.recordsFiltered = restrictions.ToList().Count.ToString();

            data.data = restrictions.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            RestrictionDetailView vm = new RestrictionDetailView();
            GetRestrictionRequest request = new GetRestrictionRequest();
            request.RestrictionId = id;
            GetRestrictionResponse response = _restrictionService.GetRestriction(request);
            if (response.RestrictionFound)
                vm = response.Restriction.ConvertToRestrictionDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(RestrictionDetailView vm)
        {
            GetRestrictionRequest request = new GetRestrictionRequest();
            request.RestrictionId = vm.RestrictionId;
           
            ModifyRestrictionRequest updateRequest = _restrictionService.GetRestriction(request).Restriction.ConvertToModifyRestrictionRequest();

            updateRequest.RestrictionId = vm.RestrictionId;
            updateRequest.RestrictionName = vm.RestrictionName;
            updateRequest.RequirePermission = vm.RequirePermission;
            updateRequest.RestrictionDescription = vm.RestrictionDescription;

            ModifyRestrictionResponse response = _restrictionService.ModifyRestriction(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(RestrictionDetailView vm)
        {
            CreateRestrictionRequest request = new CreateRestrictionRequest();
            request.RestrictionName = vm.RestrictionName;
            request.RequirePermission = vm.RequirePermission;
            request.RestrictionDescription = vm.RestrictionDescription;
            CreateRestrictionResponse response = _restrictionService.CreateRestriction(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveRestrictionRequest request = new RemoveRestrictionRequest();
            request.RestrictionId = id;
            RemoveRestrictionResponse response = _restrictionService.RemoveRestriction(request);
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

              //                  CreateRestrictionRequest request = new CreateRestrictionRequest();
             //                   request.RestrictionId = csvReader[0];
             //                   request.RestrictionName = csvReader[0];
             //                   request.RequirePermission = csvReader[0];
             //                   request.RestrictionDescription = csvReader[0];
             //                 CreateRestrictionResponse response = _restrictionService.CreateRestriction(request);

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
