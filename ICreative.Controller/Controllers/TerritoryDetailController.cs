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
    public class TerritoryDetailController : Controller
    {
        private IRegionService _regionService;
private ITerritoryService _territoryService;    
               
        public TerritoryDetailController(IRegionService regionService,ITerritoryService territoryService)
        {
             _regionService = regionService;
_territoryService = territoryService;
        }
        
                
 
        public ActionResult Detail(System.String id)
        {
            return View("../Details/TerritoryDetail", id);
        }

        public JsonResult GetTerritory(System.String id)
        {
            DataTableViewModel data1;

            GetTerritoryRequest request = new GetTerritoryRequest();
            request.TerritoryID = id;
            DetailTerritory_TerritoryDetailView data = _territoryService.GetTerritory(request).Territory.ConvertToDetailTerritory_TerritoryDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetEmployeeDataTable(System.String id)
        {
            DataTableViewModel data;

            GetTerritoryRequest request = new GetTerritoryRequest();
            request.TerritoryID = id;
            TerritoryView territory = _territoryService.GetTerritory(request).Territory;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = territory.Employees.ToList().Count.ToString();
            data.recordsFiltered = territory.Employees.ToList().Count.ToString();

            data.data = territory.Employees.ConvertToDetailTerritoryEmployeeDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
