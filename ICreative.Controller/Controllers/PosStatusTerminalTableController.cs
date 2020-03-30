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
    public class PosStatusTerminalTableController : Controller
    {

        private IPosStatusTerminalService _posStatusTerminalService;    
               
        public PosStatusTerminalTableController(IPosStatusTerminalService posStatusTerminalService)
        {
             _posStatusTerminalService = posStatusTerminalService;
        }
 
        public ActionResult Index()
        {
            PosStatusTerminalTableViewModel model = new PosStatusTerminalTableViewModel();
            return View("../Datatables/PosStatusTerminalTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PosStatusTerminalFlatViewModel> posStatusTerminals;
            posStatusTerminals = _posStatusTerminalService.GetAllPosStatusTerminals().PosStatusTerminals.ConvertToPosStatusTerminalFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posStatusTerminals.ToList().Count.ToString();
            data.recordsFiltered = posStatusTerminals.ToList().Count.ToString();

            data.data = posStatusTerminals.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PosStatusTerminalDetailView vm = new PosStatusTerminalDetailView();
            GetPosStatusTerminalRequest request = new GetPosStatusTerminalRequest();
            request.TerminalStatusId = id;
            GetPosStatusTerminalResponse response = _posStatusTerminalService.GetPosStatusTerminal(request);
            if (response.PosStatusTerminalFound)
                vm = response.PosStatusTerminal.ConvertToPosStatusTerminalDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PosStatusTerminalDetailView vm)
        {
            GetPosStatusTerminalRequest request = new GetPosStatusTerminalRequest();
            request.TerminalStatusId = vm.TerminalStatusId;
           
            ModifyPosStatusTerminalRequest updateRequest = _posStatusTerminalService.GetPosStatusTerminal(request).PosStatusTerminal.ConvertToModifyPosStatusTerminalRequest();

            updateRequest.TerminalStatusId = vm.TerminalStatusId;
            updateRequest.StatusName = vm.StatusName;

            ModifyPosStatusTerminalResponse response = _posStatusTerminalService.ModifyPosStatusTerminal(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PosStatusTerminalDetailView vm)
        {
            CreatePosStatusTerminalRequest request = new CreatePosStatusTerminalRequest();
            request.StatusName = vm.StatusName;
            CreatePosStatusTerminalResponse response = _posStatusTerminalService.CreatePosStatusTerminal(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePosStatusTerminalRequest request = new RemovePosStatusTerminalRequest();
            request.TerminalStatusId = id;
            RemovePosStatusTerminalResponse response = _posStatusTerminalService.RemovePosStatusTerminal(request);
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

              //                  CreatePosStatusTerminalRequest request = new CreatePosStatusTerminalRequest();
             //                   request.TerminalStatusId = csvReader[0];
             //                   request.StatusName = csvReader[0];
             //                 CreatePosStatusTerminalResponse response = _posStatusTerminalService.CreatePosStatusTerminal(request);

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
