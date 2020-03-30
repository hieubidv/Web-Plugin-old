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
    public class PosSimDetailController : Controller
    {
        private IPosSimService _posSimService;
private IPosSimProviderService _posSimProviderService;
private IPosStatusSimService _posStatusSimService;    
               
        public PosSimDetailController(IPosSimService posSimService,IPosSimProviderService posSimProviderService,IPosStatusSimService posStatusSimService)
        {
             _posSimService = posSimService;
_posSimProviderService = posSimProviderService;
_posStatusSimService = posStatusSimService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PosSimDetail", id);
        }

        public JsonResult GetPosSim(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPosSimRequest request = new GetPosSimRequest();
            request.SimId = id;
            DetailPosSim_PosSimDetailView data = _posSimService.GetPosSim(request).PosSim.ConvertToDetailPosSim_PosSimDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPosTerminalDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosSimRequest request = new GetPosSimRequest();
            request.SimId = id;
            PosSimView posSim = _posSimService.GetPosSim(request).PosSim;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posSim.PosTerminals.ToList().Count.ToString();
            data.recordsFiltered = posSim.PosTerminals.ToList().Count.ToString();

            data.data = posSim.PosTerminals.ConvertToDetailPosSimPosTerminalDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
