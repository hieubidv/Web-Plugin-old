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
    public class ShipperTableController : Controller
    {

        private IShipperService _shipperService;    
               
        public ShipperTableController(IShipperService shipperService)
        {
             _shipperService = shipperService;
        }
 
        public ActionResult Index()
        {
            ShipperTableViewModel model = new ShipperTableViewModel();
            return View("../Datatables/ShipperTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<ShipperFlatViewModel> shippers;
            shippers = _shipperService.GetAllShippers().Shippers.ConvertToShipperFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = shippers.ToList().Count.ToString();
            data.recordsFiltered = shippers.ToList().Count.ToString();

            data.data = shippers.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            ShipperDetailView vm = new ShipperDetailView();
            GetShipperRequest request = new GetShipperRequest();
            request.ShipperID = id;
            GetShipperResponse response = _shipperService.GetShipper(request);
            if (response.ShipperFound)
                vm = response.Shipper.ConvertToShipperDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(ShipperDetailView vm)
        {
            GetShipperRequest request = new GetShipperRequest();
            request.ShipperID = vm.ShipperID;
           
            ModifyShipperRequest updateRequest = _shipperService.GetShipper(request).Shipper.ConvertToModifyShipperRequest();

            updateRequest.ShipperID = vm.ShipperID;
            updateRequest.CompanyName = vm.CompanyName;
            updateRequest.Phone = vm.Phone;

            ModifyShipperResponse response = _shipperService.ModifyShipper(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(ShipperDetailView vm)
        {
            CreateShipperRequest request = new CreateShipperRequest();
            request.CompanyName = vm.CompanyName;
            request.Phone = vm.Phone;
            CreateShipperResponse response = _shipperService.CreateShipper(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveShipperRequest request = new RemoveShipperRequest();
            request.ShipperID = id;
            RemoveShipperResponse response = _shipperService.RemoveShipper(request);
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

              //                  CreateShipperRequest request = new CreateShipperRequest();
             //                   request.ShipperID = csvReader[0];
             //                   request.CompanyName = csvReader[0];
             //                   request.Phone = csvReader[0];
             //                 CreateShipperResponse response = _shipperService.CreateShipper(request);

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
