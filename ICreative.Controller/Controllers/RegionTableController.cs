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
    public class RegionTableController : Controller
    {

        private IRegionService _regionService;    
               
        public RegionTableController(IRegionService regionService)
        {
             _regionService = regionService;
        }
 
        public ActionResult Index()
        {
            RegionTableViewModel model = new RegionTableViewModel();
            return View("../Datatables/RegionTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<RegionFlatViewModel> regions;
            regions = _regionService.GetAllRegions().Regions.ConvertToRegionFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = regions.ToList().Count.ToString();
            data.recordsFiltered = regions.ToList().Count.ToString();

            data.data = regions.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            RegionDetailView vm = new RegionDetailView();
            GetRegionRequest request = new GetRegionRequest();
            request.RegionID = id;
            GetRegionResponse response = _regionService.GetRegion(request);
            if (response.RegionFound)
                vm = response.Region.ConvertToRegionDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(RegionDetailView vm)
        {
            GetRegionRequest request = new GetRegionRequest();
            request.RegionID = vm.RegionID;
           
            ModifyRegionRequest updateRequest = _regionService.GetRegion(request).Region.ConvertToModifyRegionRequest();

            updateRequest.RegionID = vm.RegionID;
            updateRequest.RegionDescription = vm.RegionDescription;

            ModifyRegionResponse response = _regionService.ModifyRegion(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(RegionDetailView vm)
        {
            CreateRegionRequest request = new CreateRegionRequest();
            request.RegionDescription = vm.RegionDescription;
            CreateRegionResponse response = _regionService.CreateRegion(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveRegionRequest request = new RemoveRegionRequest();
            request.RegionID = id;
            RemoveRegionResponse response = _regionService.RemoveRegion(request);
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

              //                  CreateRegionRequest request = new CreateRegionRequest();
             //                   request.RegionID = csvReader[0];
             //                   request.RegionDescription = csvReader[0];
             //                 CreateRegionResponse response = _regionService.CreateRegion(request);

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
