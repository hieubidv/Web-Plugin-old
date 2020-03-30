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
    public class PosStatusSimDetailController : Controller
    {
        private IPosStatusSimService _posStatusSimService;    
               
        public PosStatusSimDetailController(IPosStatusSimService posStatusSimService)
        {
             _posStatusSimService = posStatusSimService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PosStatusSimDetail", id);
        }

        public JsonResult GetPosStatusSim(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPosStatusSimRequest request = new GetPosStatusSimRequest();
            request.StatusId = id;
            DetailPosStatusSim_PosStatusSimDetailView data = _posStatusSimService.GetPosStatusSim(request).PosStatusSim.ConvertToDetailPosStatusSim_PosStatusSimDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPosSimDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosStatusSimRequest request = new GetPosStatusSimRequest();
            request.StatusId = id;
            PosStatusSimView posStatusSim = _posStatusSimService.GetPosStatusSim(request).PosStatusSim;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posStatusSim.PosSims.ToList().Count.ToString();
            data.recordsFiltered = posStatusSim.PosSims.ToList().Count.ToString();

            data.data = posStatusSim.PosSims.ConvertToDetailPosStatusSimPosSimDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
