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
    public class PosDeviceTableController : Controller
    {

        private IPosDeviceService _posDeviceService;    
               
        public PosDeviceTableController(IPosDeviceService posDeviceService)
        {
             _posDeviceService = posDeviceService;
        }
 
        public ActionResult Index()
        {
            PosDeviceTableViewModel model = new PosDeviceTableViewModel();
            return View("../Datatables/PosDeviceTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PosDeviceFlatViewModel> posDevices;
            posDevices = _posDeviceService.GetAllPosDevices().PosDevices.ConvertToPosDeviceFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posDevices.ToList().Count.ToString();
            data.recordsFiltered = posDevices.ToList().Count.ToString();

            data.data = posDevices.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PosDeviceDetailView vm = new PosDeviceDetailView();
            GetPosDeviceRequest request = new GetPosDeviceRequest();
            request.DeviceId = id;
            GetPosDeviceResponse response = _posDeviceService.GetPosDevice(request);
            if (response.PosDeviceFound)
                vm = response.PosDevice.ConvertToPosDeviceDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PosDeviceDetailView vm)
        {
            GetPosDeviceRequest request = new GetPosDeviceRequest();
            request.DeviceId = vm.DeviceId;
           
            ModifyPosDeviceRequest updateRequest = _posDeviceService.GetPosDevice(request).PosDevice.ConvertToModifyPosDeviceRequest();

            updateRequest.DeviceId = vm.DeviceId;
            updateRequest.BrandId = vm.BrandId;
            updateRequest.SerialNumber = vm.SerialNumber;
            updateRequest.Model = vm.Model;

            ModifyPosDeviceResponse response = _posDeviceService.ModifyPosDevice(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PosDeviceDetailView vm)
        {
            CreatePosDeviceRequest request = new CreatePosDeviceRequest();
            request.BrandId = vm.BrandId;
            request.SerialNumber = vm.SerialNumber;
            request.Model = vm.Model;
            CreatePosDeviceResponse response = _posDeviceService.CreatePosDevice(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePosDeviceRequest request = new RemovePosDeviceRequest();
            request.DeviceId = id;
            RemovePosDeviceResponse response = _posDeviceService.RemovePosDevice(request);
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

              //                  CreatePosDeviceRequest request = new CreatePosDeviceRequest();
             //                   request.DeviceId = csvReader[0];
             //                   request.BrandId = csvReader[0];
             //                   request.SerialNumber = csvReader[0];
             //                   request.Model = csvReader[0];
             //                 CreatePosDeviceResponse response = _posDeviceService.CreatePosDevice(request);

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
