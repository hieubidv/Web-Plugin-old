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
    public class PosMerchantTableController : Controller
    {

        private IPosAddressService _posAddressService;
private IPosMerchantService _posMerchantService;    
               
        public PosMerchantTableController(IPosAddressService posAddressService,IPosMerchantService posMerchantService)
        {
             _posAddressService = posAddressService;
_posMerchantService = posMerchantService;
        }
 
        public ActionResult Index()
        {
            PosMerchantTableViewModel model = new PosMerchantTableViewModel();
            model.PosAddresses = _posAddressService.GetAllPosAddresses().PosAddresses.Select(u=>new SelectListItem() { Text = u.AddressId.ToString(), Value = u.AddressId.ToString()}).ToList();
            return View("../Datatables/PosMerchantTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PosMerchantFlatViewModel> posMerchants;
            posMerchants = _posMerchantService.GetAllPosMerchants().PosMerchants.ConvertToPosMerchantFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posMerchants.ToList().Count.ToString();
            data.recordsFiltered = posMerchants.ToList().Count.ToString();

            data.data = posMerchants.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PosMerchantDetailView vm = new PosMerchantDetailView();
            GetPosMerchantRequest request = new GetPosMerchantRequest();
            request.MerchantId = id;
            GetPosMerchantResponse response = _posMerchantService.GetPosMerchant(request);
            if (response.PosMerchantFound)
                vm = response.PosMerchant.ConvertToPosMerchantDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PosMerchantDetailView vm)
        {
            GetPosMerchantRequest request = new GetPosMerchantRequest();
            request.MerchantId = vm.MerchantId;
           
            ModifyPosMerchantRequest updateRequest = _posMerchantService.GetPosMerchant(request).PosMerchant.ConvertToModifyPosMerchantRequest();

            updateRequest.MerchantId = vm.MerchantId;
            updateRequest.MerchantName = vm.MerchantName;
               GetPosAddressRequest posAddressRequest = new GetPosAddressRequest();
            posAddressRequest.AddressId = vm.PosAddressAddressId;
            updateRequest.PosAddress = _posAddressService.GetPosAddress(posAddressRequest).PosAddress;            
            updateRequest.BusinessName = vm.BusinessName;
            updateRequest.BannerName = vm.BannerName;
            updateRequest.MerchantIdByHeadQuater = vm.MerchantIdByHeadQuater;

            ModifyPosMerchantResponse response = _posMerchantService.ModifyPosMerchant(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PosMerchantDetailView vm)
        {
            CreatePosMerchantRequest request = new CreatePosMerchantRequest();
            request.MerchantName = vm.MerchantName;
               GetPosAddressRequest posAddressRequest = new GetPosAddressRequest();
            posAddressRequest.AddressId = vm.PosAddressAddressId;
            request.PosAddress = _posAddressService.GetPosAddress(posAddressRequest).PosAddress;            
            request.BusinessName = vm.BusinessName;
            request.BannerName = vm.BannerName;
            request.MerchantIdByHeadQuater = vm.MerchantIdByHeadQuater;
            CreatePosMerchantResponse response = _posMerchantService.CreatePosMerchant(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePosMerchantRequest request = new RemovePosMerchantRequest();
            request.MerchantId = id;
            RemovePosMerchantResponse response = _posMerchantService.RemovePosMerchant(request);
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

              //                  CreatePosMerchantRequest request = new CreatePosMerchantRequest();
             //                   request.MerchantId = csvReader[0];
             //                   request.MerchantName = csvReader[0];
             //                   request.PosAddressAddressId = csvReader[0];
             //                   request.BusinessName = csvReader[0];
             //                   request.BannerName = csvReader[0];
             //                   request.MerchantIdByHeadQuater = csvReader[0];
             //                 CreatePosMerchantResponse response = _posMerchantService.CreatePosMerchant(request);

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
