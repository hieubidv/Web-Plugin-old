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
    public class PosReceiptOfTestingDetailController : Controller
    {
        private IPosMerchantService _posMerchantService;
private IPosReceiptOfTestingService _posReceiptOfTestingService;    
               
        public PosReceiptOfTestingDetailController(IPosMerchantService posMerchantService,IPosReceiptOfTestingService posReceiptOfTestingService)
        {
             _posMerchantService = posMerchantService;
_posReceiptOfTestingService = posReceiptOfTestingService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PosReceiptOfTestingDetail", id);
        }

        public JsonResult GetPosReceiptOfTesting(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPosReceiptOfTestingRequest request = new GetPosReceiptOfTestingRequest();
            request.ReceiptOfTestingId = id;
            DetailPosReceiptOfTesting_PosReceiptOfTestingDetailView data = _posReceiptOfTestingService.GetPosReceiptOfTesting(request).PosReceiptOfTesting.ConvertToDetailPosReceiptOfTesting_PosReceiptOfTestingDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPosTerminalDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosReceiptOfTestingRequest request = new GetPosReceiptOfTestingRequest();
            request.ReceiptOfTestingId = id;
            PosReceiptOfTestingView posReceiptOfTesting = _posReceiptOfTestingService.GetPosReceiptOfTesting(request).PosReceiptOfTesting;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posReceiptOfTesting.PosTerminals.ToList().Count.ToString();
            data.recordsFiltered = posReceiptOfTesting.PosTerminals.ToList().Count.ToString();

            data.data = posReceiptOfTesting.PosTerminals.ConvertToDetailPosReceiptOfTestingPosTerminalDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
