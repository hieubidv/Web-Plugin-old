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
    public class ShipperDetailController : Controller
    {
        private IShipperService _shipperService;    
               
        public ShipperDetailController(IShipperService shipperService)
        {
             _shipperService = shipperService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/ShipperDetail", id);
        }

        public JsonResult GetShipper(System.Int32 id)
        {
            DataTableViewModel data1;

            GetShipperRequest request = new GetShipperRequest();
            request.ShipperID = id;
            DetailShipper_ShipperDetailView data = _shipperService.GetShipper(request).Shipper.ConvertToDetailShipper_ShipperDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetOrderDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetShipperRequest request = new GetShipperRequest();
            request.ShipperID = id;
            ShipperView shipper = _shipperService.GetShipper(request).Shipper;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = shipper.Orders.ToList().Count.ToString();
            data.recordsFiltered = shipper.Orders.ToList().Count.ToString();

            data.data = shipper.Orders.ConvertToDetailShipperOrderDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
