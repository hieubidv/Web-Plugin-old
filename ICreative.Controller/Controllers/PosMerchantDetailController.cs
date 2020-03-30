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
    public class PosMerchantDetailController : Controller
    {
        private IPosAddressService _posAddressService;
private IPosMerchantService _posMerchantService;    
               
        public PosMerchantDetailController(IPosAddressService posAddressService,IPosMerchantService posMerchantService)
        {
             _posAddressService = posAddressService;
_posMerchantService = posMerchantService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PosMerchantDetail", id);
        }

        public JsonResult GetPosMerchant(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPosMerchantRequest request = new GetPosMerchantRequest();
            request.MerchantId = id;
            DetailPosMerchant_PosMerchantDetailView data = _posMerchantService.GetPosMerchant(request).PosMerchant.ConvertToDetailPosMerchant_PosMerchantDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPosReceiptOfTestingDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosMerchantRequest request = new GetPosMerchantRequest();
            request.MerchantId = id;
            PosMerchantView posMerchant = _posMerchantService.GetPosMerchant(request).PosMerchant;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posMerchant.PosReceiptOfTestings.ToList().Count.ToString();
            data.recordsFiltered = posMerchant.PosReceiptOfTestings.ToList().Count.ToString();

            data.data = posMerchant.PosReceiptOfTestings.ConvertToDetailPosMerchantPosReceiptOfTestingDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
