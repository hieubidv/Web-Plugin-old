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
    public class PosDeviceDetailController : Controller
    {
        private IPosDeviceService _posDeviceService;    
               
        public PosDeviceDetailController(IPosDeviceService posDeviceService)
        {
             _posDeviceService = posDeviceService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PosDeviceDetail", id);
        }

        public JsonResult GetPosDevice(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPosDeviceRequest request = new GetPosDeviceRequest();
            request.DeviceId = id;
            DetailPosDevice_PosDeviceDetailView data = _posDeviceService.GetPosDevice(request).PosDevice.ConvertToDetailPosDevice_PosDeviceDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPosTerminalDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosDeviceRequest request = new GetPosDeviceRequest();
            request.DeviceId = id;
            PosDeviceView posDevice = _posDeviceService.GetPosDevice(request).PosDevice;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posDevice.PosTerminals.ToList().Count.ToString();
            data.recordsFiltered = posDevice.PosTerminals.ToList().Count.ToString();

            data.data = posDevice.PosTerminals.ConvertToDetailPosDevicePosTerminalDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
