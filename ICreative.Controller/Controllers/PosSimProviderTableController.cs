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
    public class PosSimProviderTableController : Controller
    {

        private IPosSimProviderService _posSimProviderService;    
               
        public PosSimProviderTableController(IPosSimProviderService posSimProviderService)
        {
             _posSimProviderService = posSimProviderService;
        }
 
        public ActionResult Index()
        {
            PosSimProviderTableViewModel model = new PosSimProviderTableViewModel();
            return View("../Datatables/PosSimProviderTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PosSimProviderFlatViewModel> posSimProviders;
            posSimProviders = _posSimProviderService.GetAllPosSimProviders().PosSimProviders.ConvertToPosSimProviderFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posSimProviders.ToList().Count.ToString();
            data.recordsFiltered = posSimProviders.ToList().Count.ToString();

            data.data = posSimProviders.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PosSimProviderDetailView vm = new PosSimProviderDetailView();
            GetPosSimProviderRequest request = new GetPosSimProviderRequest();
            request.SimProviderId = id;
            GetPosSimProviderResponse response = _posSimProviderService.GetPosSimProvider(request);
            if (response.PosSimProviderFound)
                vm = response.PosSimProvider.ConvertToPosSimProviderDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PosSimProviderDetailView vm)
        {
            GetPosSimProviderRequest request = new GetPosSimProviderRequest();
            request.SimProviderId = vm.SimProviderId;
           
            ModifyPosSimProviderRequest updateRequest = _posSimProviderService.GetPosSimProvider(request).PosSimProvider.ConvertToModifyPosSimProviderRequest();

            updateRequest.SimProviderId = vm.SimProviderId;
            updateRequest.SimProviderName = vm.SimProviderName;

            ModifyPosSimProviderResponse response = _posSimProviderService.ModifyPosSimProvider(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PosSimProviderDetailView vm)
        {
            CreatePosSimProviderRequest request = new CreatePosSimProviderRequest();
            request.SimProviderName = vm.SimProviderName;
            CreatePosSimProviderResponse response = _posSimProviderService.CreatePosSimProvider(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePosSimProviderRequest request = new RemovePosSimProviderRequest();
            request.SimProviderId = id;
            RemovePosSimProviderResponse response = _posSimProviderService.RemovePosSimProvider(request);
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

              //                  CreatePosSimProviderRequest request = new CreatePosSimProviderRequest();
             //                   request.SimProviderId = csvReader[0];
             //                   request.SimProviderName = csvReader[0];
             //                 CreatePosSimProviderResponse response = _posSimProviderService.CreatePosSimProvider(request);

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
