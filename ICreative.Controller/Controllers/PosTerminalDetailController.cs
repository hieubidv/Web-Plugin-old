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
    public class PosTerminalDetailController : Controller
    {
        private IPosDeviceService _posDeviceService;
private IPosSimService _posSimService;
private IPosStatusTerminalService _posStatusTerminalService;
private IPosTerminalService _posTerminalService;    
               
        public PosTerminalDetailController(IPosDeviceService posDeviceService,IPosSimService posSimService,IPosStatusTerminalService posStatusTerminalService,IPosTerminalService posTerminalService)
        {
             _posDeviceService = posDeviceService;
_posSimService = posSimService;
_posStatusTerminalService = posStatusTerminalService;
_posTerminalService = posTerminalService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PosTerminalDetail", id);
        }

        public JsonResult GetPosTerminal(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPosTerminalRequest request = new GetPosTerminalRequest();
            request.TerminalId = id;
            DetailPosTerminal_PosTerminalDetailView data = _posTerminalService.GetPosTerminal(request).PosTerminal.ConvertToDetailPosTerminal_PosTerminalDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPosReceiptOfDeliveryDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosTerminalRequest request = new GetPosTerminalRequest();
            request.TerminalId = id;
            PosTerminalView posTerminal = _posTerminalService.GetPosTerminal(request).PosTerminal;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posTerminal.PosReceiptOfDeliveries.ToList().Count.ToString();
            data.recordsFiltered = posTerminal.PosReceiptOfDeliveries.ToList().Count.ToString();

            data.data = posTerminal.PosReceiptOfDeliveries.ConvertToDetailPosTerminalPosReceiptOfDeliveryDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPosReceiptOfTestingDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosTerminalRequest request = new GetPosTerminalRequest();
            request.TerminalId = id;
            PosTerminalView posTerminal = _posTerminalService.GetPosTerminal(request).PosTerminal;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posTerminal.PosReceiptOfTestings.ToList().Count.ToString();
            data.recordsFiltered = posTerminal.PosReceiptOfTestings.ToList().Count.ToString();

            data.data = posTerminal.PosReceiptOfTestings.ConvertToDetailPosTerminalPosReceiptOfTestingDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
