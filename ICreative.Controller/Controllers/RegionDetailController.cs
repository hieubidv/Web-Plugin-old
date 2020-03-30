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
    public class RegionDetailController : Controller
    {
        private IRegionService _regionService;    
               
        public RegionDetailController(IRegionService regionService)
        {
             _regionService = regionService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/RegionDetail", id);
        }

        public JsonResult GetRegion(System.Int32 id)
        {
            DataTableViewModel data1;

            GetRegionRequest request = new GetRegionRequest();
            request.RegionID = id;
            DetailRegion_RegionDetailView data = _regionService.GetRegion(request).Region.ConvertToDetailRegion_RegionDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetTerritoryDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetRegionRequest request = new GetRegionRequest();
            request.RegionID = id;
            RegionView region = _regionService.GetRegion(request).Region;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = region.Territories.ToList().Count.ToString();
            data.recordsFiltered = region.Territories.ToList().Count.ToString();

            data.data = region.Territories.ConvertToDetailRegionTerritoryDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
