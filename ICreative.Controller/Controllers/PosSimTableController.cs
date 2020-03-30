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
    public class PosSimTableController : Controller
    {

        private IPosSimService _posSimService;
private IPosSimProviderService _posSimProviderService;
private IPosStatusSimService _posStatusSimService;    
               
        public PosSimTableController(IPosSimService posSimService,IPosSimProviderService posSimProviderService,IPosStatusSimService posStatusSimService)
        {
             _posSimService = posSimService;
_posSimProviderService = posSimProviderService;
_posStatusSimService = posStatusSimService;
        }
 
        public ActionResult Index()
        {
            PosSimTableViewModel model = new PosSimTableViewModel();
            model.PosStatusSims = _posStatusSimService.GetAllPosStatusSims().PosStatusSims.Select(u=>new SelectListItem() { Text = u.StatusName, Value = u.StatusId.ToString()}).ToList();
            model.PosSimProviders = _posSimProviderService.GetAllPosSimProviders().PosSimProviders.Select(u=>new SelectListItem() { Text = u.SimProviderName, Value = u.SimProviderId.ToString()}).ToList();
            return View("../Datatables/PosSimTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PosSimFlatViewModel> posSims;
            posSims = _posSimService.GetAllPosSims().PosSims.ConvertToPosSimFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posSims.ToList().Count.ToString();
            data.recordsFiltered = posSims.ToList().Count.ToString();

            data.data = posSims.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PosSimDetailView vm = new PosSimDetailView();
            GetPosSimRequest request = new GetPosSimRequest();
            request.SimId = id;
            GetPosSimResponse response = _posSimService.GetPosSim(request);
            if (response.PosSimFound)
                vm = response.PosSim.ConvertToPosSimDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PosSimDetailView vm)
        {
            GetPosSimRequest request = new GetPosSimRequest();
            request.SimId = vm.SimId;
           
            ModifyPosSimRequest updateRequest = _posSimService.GetPosSim(request).PosSim.ConvertToModifyPosSimRequest();

            updateRequest.SimId = vm.SimId;
            updateRequest.SimCode = vm.SimCode;
            updateRequest.SimPhoneNumber = vm.SimPhoneNumber;
               GetPosStatusSimRequest posStatusSimRequest = new GetPosStatusSimRequest();
            posStatusSimRequest.StatusId = vm.PosStatusSimStatusId;
            updateRequest.PosStatusSim = _posStatusSimService.GetPosStatusSim(posStatusSimRequest).PosStatusSim;            
            updateRequest.AddedDate = vm.AddedDate;
               GetPosSimProviderRequest posSimProviderRequest = new GetPosSimProviderRequest();
            posSimProviderRequest.SimProviderId = vm.PosSimProviderSimProviderId;
            updateRequest.PosSimProvider = _posSimProviderService.GetPosSimProvider(posSimProviderRequest).PosSimProvider;            

            ModifyPosSimResponse response = _posSimService.ModifyPosSim(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PosSimDetailView vm)
        {
            CreatePosSimRequest request = new CreatePosSimRequest();
            request.SimCode = vm.SimCode;
            request.SimPhoneNumber = vm.SimPhoneNumber;
               GetPosStatusSimRequest posStatusSimRequest = new GetPosStatusSimRequest();
            posStatusSimRequest.StatusId = vm.PosStatusSimStatusId;
            request.PosStatusSim = _posStatusSimService.GetPosStatusSim(posStatusSimRequest).PosStatusSim;            
            request.AddedDate = vm.AddedDate;
               GetPosSimProviderRequest posSimProviderRequest = new GetPosSimProviderRequest();
            posSimProviderRequest.SimProviderId = vm.PosSimProviderSimProviderId;
            request.PosSimProvider = _posSimProviderService.GetPosSimProvider(posSimProviderRequest).PosSimProvider;            
            CreatePosSimResponse response = _posSimService.CreatePosSim(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePosSimRequest request = new RemovePosSimRequest();
            request.SimId = id;
            RemovePosSimResponse response = _posSimService.RemovePosSim(request);
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

              //                  CreatePosSimRequest request = new CreatePosSimRequest();
             //                   request.SimId = csvReader[0];
             //                   request.SimCode = csvReader[0];
             //                   request.SimPhoneNumber = csvReader[0];
             //                   request.PosStatusSimStatusId = csvReader[0];
             //                   request.AddedDate = csvReader[0];
             //                   request.PosSimProviderSimProviderId = csvReader[0];
             //                 CreatePosSimResponse response = _posSimService.CreatePosSim(request);

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
