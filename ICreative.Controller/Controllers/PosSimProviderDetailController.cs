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
    public class PosSimProviderDetailController : Controller
    {
        private IPosSimProviderService _posSimProviderService;    
               
        public PosSimProviderDetailController(IPosSimProviderService posSimProviderService)
        {
             _posSimProviderService = posSimProviderService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PosSimProviderDetail", id);
        }

        public JsonResult GetPosSimProvider(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPosSimProviderRequest request = new GetPosSimProviderRequest();
            request.SimProviderId = id;
            DetailPosSimProvider_PosSimProviderDetailView data = _posSimProviderService.GetPosSimProvider(request).PosSimProvider.ConvertToDetailPosSimProvider_PosSimProviderDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPosSimDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosSimProviderRequest request = new GetPosSimProviderRequest();
            request.SimProviderId = id;
            PosSimProviderView posSimProvider = _posSimProviderService.GetPosSimProvider(request).PosSimProvider;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posSimProvider.PosSims.ToList().Count.ToString();
            data.recordsFiltered = posSimProvider.PosSims.ToList().Count.ToString();

            data.data = posSimProvider.PosSims.ConvertToDetailPosSimProviderPosSimDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
