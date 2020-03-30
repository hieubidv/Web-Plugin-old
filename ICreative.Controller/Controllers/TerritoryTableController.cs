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
    public class TerritoryTableController : Controller
    {

        private IRegionService _regionService;
private ITerritoryService _territoryService;    
               
        public TerritoryTableController(IRegionService regionService,ITerritoryService territoryService)
        {
             _regionService = regionService;
_territoryService = territoryService;
        }
 
        public ActionResult Index()
        {
            TerritoryTableViewModel model = new TerritoryTableViewModel();
            model.Regions = _regionService.GetAllRegions().Regions.Select(u=>new SelectListItem() { Text = u.RegionID.ToString(), Value = u.RegionID.ToString()}).ToList();
            return View("../Datatables/TerritoryTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<TerritoryFlatViewModel> territories;
            territories = _territoryService.GetAllTerritories().Territories.ConvertToTerritoryFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = territories.ToList().Count.ToString();
            data.recordsFiltered = territories.ToList().Count.ToString();

            data.data = territories.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.String id)
        {  
            TerritoryDetailView vm = new TerritoryDetailView();
            GetTerritoryRequest request = new GetTerritoryRequest();
            request.TerritoryID = id;
            GetTerritoryResponse response = _territoryService.GetTerritory(request);
            if (response.TerritoryFound)
                vm = response.Territory.ConvertToTerritoryDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(TerritoryDetailView vm)
        {
            GetTerritoryRequest request = new GetTerritoryRequest();
            request.TerritoryID = vm.TerritoryID;
           
            ModifyTerritoryRequest updateRequest = _territoryService.GetTerritory(request).Territory.ConvertToModifyTerritoryRequest();

            updateRequest.TerritoryID = vm.TerritoryID;
            updateRequest.TerritoryDescription = vm.TerritoryDescription;
               GetRegionRequest regionRequest = new GetRegionRequest();
            regionRequest.RegionID = vm.RegionRegionID;
            updateRequest.Region = _regionService.GetRegion(regionRequest).Region;            

            ModifyTerritoryResponse response = _territoryService.ModifyTerritory(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(TerritoryDetailView vm)
        {
            CreateTerritoryRequest request = new CreateTerritoryRequest();
            request.TerritoryDescription = vm.TerritoryDescription;
               GetRegionRequest regionRequest = new GetRegionRequest();
            regionRequest.RegionID = vm.RegionRegionID;
            request.Region = _regionService.GetRegion(regionRequest).Region;            
            CreateTerritoryResponse response = _territoryService.CreateTerritory(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.String id)
        {
            RemoveTerritoryRequest request = new RemoveTerritoryRequest();
            request.TerritoryID = id;
            RemoveTerritoryResponse response = _territoryService.RemoveTerritory(request);
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

              //                  CreateTerritoryRequest request = new CreateTerritoryRequest();
             //                   request.TerritoryID = csvReader[0];
             //                   request.TerritoryDescription = csvReader[0];
             //                   request.RegionRegionID = csvReader[0];
             //                 CreateTerritoryResponse response = _territoryService.CreateTerritory(request);

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
