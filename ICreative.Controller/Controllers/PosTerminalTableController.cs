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
    public class PosTerminalTableController : Controller
    {

        private IPosDeviceService _posDeviceService;
private IPosSimService _posSimService;
private IPosStatusTerminalService _posStatusTerminalService;
private IPosTerminalService _posTerminalService;    
               
        public PosTerminalTableController(IPosDeviceService posDeviceService,IPosSimService posSimService,IPosStatusTerminalService posStatusTerminalService,IPosTerminalService posTerminalService)
        {
             _posDeviceService = posDeviceService;
_posSimService = posSimService;
_posStatusTerminalService = posStatusTerminalService;
_posTerminalService = posTerminalService;
        }
 
        public ActionResult Index()
        {
            PosTerminalTableViewModel model = new PosTerminalTableViewModel();
            model.PosDevices = _posDeviceService.GetAllPosDevices().PosDevices.Select(u=>new SelectListItem() { Text = u.DeviceId.ToString(), Value = u.DeviceId.ToString()}).ToList();
            model.PosStatusTerminals = _posStatusTerminalService.GetAllPosStatusTerminals().PosStatusTerminals.Select(u=>new SelectListItem() { Text = u.StatusName, Value = u.TerminalStatusId.ToString()}).ToList();
            model.PosSims = _posSimService.GetAllPosSims().PosSims.Select(u=>new SelectListItem() { Text = u.SimId.ToString(), Value = u.SimId.ToString()}).ToList();
            return View("../Datatables/PosTerminalTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PosTerminalFlatViewModel> posTerminals;
            posTerminals = _posTerminalService.GetAllPosTerminals().PosTerminals.ConvertToPosTerminalFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posTerminals.ToList().Count.ToString();
            data.recordsFiltered = posTerminals.ToList().Count.ToString();

            data.data = posTerminals.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PosTerminalDetailView vm = new PosTerminalDetailView();
            GetPosTerminalRequest request = new GetPosTerminalRequest();
            request.TerminalId = id;
            GetPosTerminalResponse response = _posTerminalService.GetPosTerminal(request);
            if (response.PosTerminalFound)
                vm = response.PosTerminal.ConvertToPosTerminalDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PosTerminalDetailView vm)
        {
            GetPosTerminalRequest request = new GetPosTerminalRequest();
            request.TerminalId = vm.TerminalId;
           
            ModifyPosTerminalRequest updateRequest = _posTerminalService.GetPosTerminal(request).PosTerminal.ConvertToModifyPosTerminalRequest();

            updateRequest.TerminalId = vm.TerminalId;
            updateRequest.TerminalIdByHeadQuater = vm.TerminalIdByHeadQuater;
            updateRequest.InitializeCode = vm.InitializeCode;
               GetPosDeviceRequest posDeviceRequest = new GetPosDeviceRequest();
            posDeviceRequest.DeviceId = vm.PosDeviceDeviceId;
            updateRequest.PosDevice = _posDeviceService.GetPosDevice(posDeviceRequest).PosDevice;            
               GetPosStatusTerminalRequest posStatusTerminalRequest = new GetPosStatusTerminalRequest();
            posStatusTerminalRequest.TerminalStatusId = vm.PosStatusTerminalTerminalStatusId;
            updateRequest.PosStatusTerminal = _posStatusTerminalService.GetPosStatusTerminal(posStatusTerminalRequest).PosStatusTerminal;            
               GetPosSimRequest posSimRequest = new GetPosSimRequest();
            posSimRequest.SimId = vm.PosSimSimId;
            updateRequest.PosSim = _posSimService.GetPosSim(posSimRequest).PosSim;            
            updateRequest.ConnectType = vm.ConnectType;

            ModifyPosTerminalResponse response = _posTerminalService.ModifyPosTerminal(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PosTerminalDetailView vm)
        {
            CreatePosTerminalRequest request = new CreatePosTerminalRequest();
            request.TerminalIdByHeadQuater = vm.TerminalIdByHeadQuater;
            request.InitializeCode = vm.InitializeCode;
               GetPosDeviceRequest posDeviceRequest = new GetPosDeviceRequest();
            posDeviceRequest.DeviceId = vm.PosDeviceDeviceId;
            request.PosDevice = _posDeviceService.GetPosDevice(posDeviceRequest).PosDevice;            
               GetPosStatusTerminalRequest posStatusTerminalRequest = new GetPosStatusTerminalRequest();
            posStatusTerminalRequest.TerminalStatusId = vm.PosStatusTerminalTerminalStatusId;
            request.PosStatusTerminal = _posStatusTerminalService.GetPosStatusTerminal(posStatusTerminalRequest).PosStatusTerminal;            
               GetPosSimRequest posSimRequest = new GetPosSimRequest();
            posSimRequest.SimId = vm.PosSimSimId;
            request.PosSim = _posSimService.GetPosSim(posSimRequest).PosSim;            
            request.ConnectType = vm.ConnectType;
            CreatePosTerminalResponse response = _posTerminalService.CreatePosTerminal(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePosTerminalRequest request = new RemovePosTerminalRequest();
            request.TerminalId = id;
            RemovePosTerminalResponse response = _posTerminalService.RemovePosTerminal(request);
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

              //                  CreatePosTerminalRequest request = new CreatePosTerminalRequest();
             //                   request.TerminalId = csvReader[0];
             //                   request.TerminalIdByHeadQuater = csvReader[0];
             //                   request.InitializeCode = csvReader[0];
             //                   request.PosDeviceDeviceId = csvReader[0];
             //                   request.PosStatusTerminalTerminalStatusId = csvReader[0];
             //                   request.PosSimSimId = csvReader[0];
             //                   request.ConnectType = csvReader[0];
             //                 CreatePosTerminalResponse response = _posTerminalService.CreatePosTerminal(request);

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
