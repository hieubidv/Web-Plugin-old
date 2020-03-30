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
    public class PosStatusSimTableController : Controller
    {

        private IPosStatusSimService _posStatusSimService;    
               
        public PosStatusSimTableController(IPosStatusSimService posStatusSimService)
        {
             _posStatusSimService = posStatusSimService;
        }
 
        public ActionResult Index()
        {
            PosStatusSimTableViewModel model = new PosStatusSimTableViewModel();
            return View("../Datatables/PosStatusSimTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PosStatusSimFlatViewModel> posStatusSims;
            posStatusSims = _posStatusSimService.GetAllPosStatusSims().PosStatusSims.ConvertToPosStatusSimFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posStatusSims.ToList().Count.ToString();
            data.recordsFiltered = posStatusSims.ToList().Count.ToString();

            data.data = posStatusSims.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PosStatusSimDetailView vm = new PosStatusSimDetailView();
            GetPosStatusSimRequest request = new GetPosStatusSimRequest();
            request.StatusId = id;
            GetPosStatusSimResponse response = _posStatusSimService.GetPosStatusSim(request);
            if (response.PosStatusSimFound)
                vm = response.PosStatusSim.ConvertToPosStatusSimDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PosStatusSimDetailView vm)
        {
            GetPosStatusSimRequest request = new GetPosStatusSimRequest();
            request.StatusId = vm.StatusId;
           
            ModifyPosStatusSimRequest updateRequest = _posStatusSimService.GetPosStatusSim(request).PosStatusSim.ConvertToModifyPosStatusSimRequest();

            updateRequest.StatusId = vm.StatusId;
            updateRequest.StatusName = vm.StatusName;

            ModifyPosStatusSimResponse response = _posStatusSimService.ModifyPosStatusSim(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PosStatusSimDetailView vm)
        {
            CreatePosStatusSimRequest request = new CreatePosStatusSimRequest();
            request.StatusName = vm.StatusName;
            CreatePosStatusSimResponse response = _posStatusSimService.CreatePosStatusSim(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePosStatusSimRequest request = new RemovePosStatusSimRequest();
            request.StatusId = id;
            RemovePosStatusSimResponse response = _posStatusSimService.RemovePosStatusSim(request);
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

              //                  CreatePosStatusSimRequest request = new CreatePosStatusSimRequest();
             //                   request.StatusId = csvReader[0];
             //                   request.StatusName = csvReader[0];
             //                 CreatePosStatusSimResponse response = _posStatusSimService.CreatePosStatusSim(request);

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
