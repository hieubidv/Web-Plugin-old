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
    public class RestrictionDetailController : Controller
    {
        private IRestrictionService _restrictionService;    
               
        public RestrictionDetailController(IRestrictionService restrictionService)
        {
             _restrictionService = restrictionService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/RestrictionDetail", id);
        }

        public JsonResult GetRestriction(System.Int32 id)
        {
            DataTableViewModel data1;

            GetRestrictionRequest request = new GetRestrictionRequest();
            request.RestrictionId = id;
            DetailRestriction_RestrictionDetailView data = _restrictionService.GetRestriction(request).Restriction.ConvertToDetailRestriction_RestrictionDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        



        
    }
}
