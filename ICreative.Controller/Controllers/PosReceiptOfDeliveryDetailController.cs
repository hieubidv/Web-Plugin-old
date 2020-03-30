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
    public class PosReceiptOfDeliveryDetailController : Controller
    {
        private IPosReceiptOfDeliveryService _posReceiptOfDeliveryService;
private IUserService _userService;    
               
        public PosReceiptOfDeliveryDetailController(IPosReceiptOfDeliveryService posReceiptOfDeliveryService,IUserService userService)
        {
             _posReceiptOfDeliveryService = posReceiptOfDeliveryService;
_userService = userService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PosReceiptOfDeliveryDetail", id);
        }

        public JsonResult GetPosReceiptOfDelivery(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPosReceiptOfDeliveryRequest request = new GetPosReceiptOfDeliveryRequest();
            request.PosReceiptOfDeliveryId = id;
            DetailPosReceiptOfDelivery_PosReceiptOfDeliveryDetailView data = _posReceiptOfDeliveryService.GetPosReceiptOfDelivery(request).PosReceiptOfDelivery.ConvertToDetailPosReceiptOfDelivery_PosReceiptOfDeliveryDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPosTerminalDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosReceiptOfDeliveryRequest request = new GetPosReceiptOfDeliveryRequest();
            request.PosReceiptOfDeliveryId = id;
            PosReceiptOfDeliveryView posReceiptOfDelivery = _posReceiptOfDeliveryService.GetPosReceiptOfDelivery(request).PosReceiptOfDelivery;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posReceiptOfDelivery.PosTerminals.ToList().Count.ToString();
            data.recordsFiltered = posReceiptOfDelivery.PosTerminals.ToList().Count.ToString();

            data.data = posReceiptOfDelivery.PosTerminals.ConvertToDetailPosReceiptOfDeliveryPosTerminalDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
