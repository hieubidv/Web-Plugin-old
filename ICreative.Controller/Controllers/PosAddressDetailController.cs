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
    public class PosAddressDetailController : Controller
    {
        private IPosAddressService _posAddressService;    
               
        public PosAddressDetailController(IPosAddressService posAddressService)
        {
             _posAddressService = posAddressService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PosAddressDetail", id);
        }

        public JsonResult GetPosAddress(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPosAddressRequest request = new GetPosAddressRequest();
            request.AddressId = id;
            DetailPosAddress_PosAddressDetailView data = _posAddressService.GetPosAddress(request).PosAddress.ConvertToDetailPosAddress_PosAddressDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPosMerchantDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosAddressRequest request = new GetPosAddressRequest();
            request.AddressId = id;
            PosAddressView posAddress = _posAddressService.GetPosAddress(request).PosAddress;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posAddress.PosMerchants.ToList().Count.ToString();
            data.recordsFiltered = posAddress.PosMerchants.ToList().Count.ToString();

            data.data = posAddress.PosMerchants.ConvertToDetailPosAddressPosMerchantDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
