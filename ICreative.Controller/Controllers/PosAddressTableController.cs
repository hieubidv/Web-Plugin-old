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
    public class PosAddressTableController : Controller
    {

        private IPosAddressService _posAddressService;    
               
        public PosAddressTableController(IPosAddressService posAddressService)
        {
             _posAddressService = posAddressService;
        }
 
        public ActionResult Index()
        {
            PosAddressTableViewModel model = new PosAddressTableViewModel();
            return View("../Datatables/PosAddressTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PosAddressFlatViewModel> posAddresses;
            posAddresses = _posAddressService.GetAllPosAddresses().PosAddresses.ConvertToPosAddressFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posAddresses.ToList().Count.ToString();
            data.recordsFiltered = posAddresses.ToList().Count.ToString();

            data.data = posAddresses.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PosAddressDetailView vm = new PosAddressDetailView();
            GetPosAddressRequest request = new GetPosAddressRequest();
            request.AddressId = id;
            GetPosAddressResponse response = _posAddressService.GetPosAddress(request);
            if (response.PosAddressFound)
                vm = response.PosAddress.ConvertToPosAddressDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PosAddressDetailView vm)
        {
            GetPosAddressRequest request = new GetPosAddressRequest();
            request.AddressId = vm.AddressId;
           
            ModifyPosAddressRequest updateRequest = _posAddressService.GetPosAddress(request).PosAddress.ConvertToModifyPosAddressRequest();

            updateRequest.AddressId = vm.AddressId;
            updateRequest.Address = vm.Address;

            ModifyPosAddressResponse response = _posAddressService.ModifyPosAddress(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PosAddressDetailView vm)
        {
            CreatePosAddressRequest request = new CreatePosAddressRequest();
            request.Address = vm.Address;
            CreatePosAddressResponse response = _posAddressService.CreatePosAddress(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePosAddressRequest request = new RemovePosAddressRequest();
            request.AddressId = id;
            RemovePosAddressResponse response = _posAddressService.RemovePosAddress(request);
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

              //                  CreatePosAddressRequest request = new CreatePosAddressRequest();
             //                   request.AddressId = csvReader[0];
             //                   request.Address = csvReader[0];
             //                 CreatePosAddressResponse response = _posAddressService.CreatePosAddress(request);

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
