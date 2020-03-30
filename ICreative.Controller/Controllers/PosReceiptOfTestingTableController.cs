using System;
using System.Web.Mvc;
using System.Linq;
using ICreative.Services.Interfaces;
using ICreative.Services.ViewModels;
using ICreative.Controllers.ViewModels;
using System.Collections.Generic;
using ICreative.Controllers.Mapping;
using ICreative.Controllers.Datatables;
using ICreative.Services.Messaging;
using ICreative.Controllers.ViewModels.Datatable;
using System.Web;
using System.IO;
namespace ICreative.Controllers.Controllers
{
    public class PosReceiptOfTestingTableController : Controller
    {

        private IPosMerchantService _posMerchantService;
private IPosReceiptOfTestingService _posReceiptOfTestingService;    
               
        public PosReceiptOfTestingTableController(IPosMerchantService posMerchantService,IPosReceiptOfTestingService posReceiptOfTestingService)
        {
             _posMerchantService = posMerchantService;
_posReceiptOfTestingService = posReceiptOfTestingService;
        }
 
        public ActionResult Index()
        {
            PosReceiptOfTestingTableViewModel model = new PosReceiptOfTestingTableViewModel();
            model.PosMerchants = _posMerchantService.GetAllPosMerchants().PosMerchants.Select(u=>new SelectListItem() { Text = u.MerchantName, Value = u.MerchantId.ToString()}).ToList();
            return View("../Datatables/PosReceiptOfTestingTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PosReceiptOfTestingFlatViewModel> posReceiptOfTestings;
            posReceiptOfTestings = _posReceiptOfTestingService.GetAllPosReceiptOfTestings().PosReceiptOfTestings.ConvertToPosReceiptOfTestingFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posReceiptOfTestings.ToList().Count.ToString();
            data.recordsFiltered = posReceiptOfTestings.ToList().Count.ToString();

            data.data = posReceiptOfTestings.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PosReceiptOfTestingDetailView vm = new PosReceiptOfTestingDetailView();
            GetPosReceiptOfTestingRequest request = new GetPosReceiptOfTestingRequest();
            request.ReceiptOfTestingId = id;
            GetPosReceiptOfTestingResponse response = _posReceiptOfTestingService.GetPosReceiptOfTesting(request);
            if (response.PosReceiptOfTestingFound)
                vm = response.PosReceiptOfTesting.ConvertToPosReceiptOfTestingDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PosReceiptOfTestingDetailView vm)
        {
            GetPosReceiptOfTestingRequest request = new GetPosReceiptOfTestingRequest();
            request.ReceiptOfTestingId = vm.ReceiptOfTestingId;
           
            ModifyPosReceiptOfTestingRequest updateRequest = _posReceiptOfTestingService.GetPosReceiptOfTesting(request).PosReceiptOfTesting.ConvertToModifyPosReceiptOfTestingRequest();

            updateRequest.ReceiptOfTestingId = vm.ReceiptOfTestingId;
            updateRequest.TestDate = vm.TestDate;
               GetPosMerchantRequest posMerchantRequest = new GetPosMerchantRequest();
            posMerchantRequest.MerchantId = vm.PosMerchantMerchantId;
            updateRequest.PosMerchant = _posMerchantService.GetPosMerchant(posMerchantRequest).PosMerchant;            
            updateRequest.AgentAName = vm.AgentAName;
            updateRequest.AgentBName = vm.AgentBName;
            updateRequest.PosId = vm.PosId;

            ModifyPosReceiptOfTestingResponse response = _posReceiptOfTestingService.ModifyPosReceiptOfTesting(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PosReceiptOfTestingDetailView vm)
        {
            CreatePosReceiptOfTestingRequest request = new CreatePosReceiptOfTestingRequest();
            request.TestDate = vm.TestDate;
               GetPosMerchantRequest posMerchantRequest = new GetPosMerchantRequest();
            posMerchantRequest.MerchantId = vm.PosMerchantMerchantId;
            request.PosMerchant = _posMerchantService.GetPosMerchant(posMerchantRequest).PosMerchant;            
            request.AgentAName = vm.AgentAName;
            request.AgentBName = vm.AgentBName;
            request.PosId = vm.PosId;
            CreatePosReceiptOfTestingResponse response = _posReceiptOfTestingService.CreatePosReceiptOfTesting(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePosReceiptOfTestingRequest request = new RemovePosReceiptOfTestingRequest();
            request.ReceiptOfTestingId = id;
            RemovePosReceiptOfTestingResponse response = _posReceiptOfTestingService.RemovePosReceiptOfTesting(request);
            return Json(response);
        }
        
        
        
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase uploadedFile)
        {
            try
            {
                if (uploadedFile.ContentLength > 0)
                {
                    if (uploadedFile.FileName.EndsWith(".csv"))
                    {
                        Stream stream = uploadedFile.InputStream;
              //          using (CsvReader csvReader =
              //              new CsvReader(new StreamReader(stream), true))
              //          {
              //              while (csvReader.ReadNextRecord())
              //              {

              //                  CreatePosReceiptOfTestingRequest request = new CreatePosReceiptOfTestingRequest();
             //                   request.ReceiptOfTestingId = csvReader[0];
             //                   request.TestDate = csvReader[0];
             //                   request.PosMerchantMerchantId = csvReader[0];
             //                   request.AgentAName = csvReader[0];
             //                   request.AgentBName = csvReader[0];
             //                   request.PosId = csvReader[0];
             //                 CreatePosReceiptOfTestingResponse response = _posReceiptOfTestingService.CreatePosReceiptOfTesting(request);

             //               }
             //           }                     
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");                     
                    }
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }        
        
    }
}
