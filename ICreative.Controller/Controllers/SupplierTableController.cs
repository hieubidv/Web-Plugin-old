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
    public class SupplierTableController : Controller
    {

        private ISupplierService _supplierService;    
               
        public SupplierTableController(ISupplierService supplierService)
        {
             _supplierService = supplierService;
        }
 
        public ActionResult Index()
        {
            SupplierTableViewModel model = new SupplierTableViewModel();
            return View("../Datatables/SupplierTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<SupplierFlatViewModel> suppliers;
            suppliers = _supplierService.GetAllSuppliers().Suppliers.ConvertToSupplierFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = suppliers.ToList().Count.ToString();
            data.recordsFiltered = suppliers.ToList().Count.ToString();

            data.data = suppliers.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            SupplierDetailView vm = new SupplierDetailView();
            GetSupplierRequest request = new GetSupplierRequest();
            request.SupplierID = id;
            GetSupplierResponse response = _supplierService.GetSupplier(request);
            if (response.SupplierFound)
                vm = response.Supplier.ConvertToSupplierDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(SupplierDetailView vm)
        {
            GetSupplierRequest request = new GetSupplierRequest();
            request.SupplierID = vm.SupplierID;
           
            ModifySupplierRequest updateRequest = _supplierService.GetSupplier(request).Supplier.ConvertToModifySupplierRequest();

            updateRequest.SupplierID = vm.SupplierID;
            updateRequest.CompanyName = vm.CompanyName;
            updateRequest.ContactName = vm.ContactName;
            updateRequest.ContactTitle = vm.ContactTitle;
            updateRequest.Address = vm.Address;
            updateRequest.City = vm.City;
            updateRequest.Region = vm.Region;
            updateRequest.PostalCode = vm.PostalCode;
            updateRequest.Country = vm.Country;
            updateRequest.Phone = vm.Phone;
            updateRequest.Fax = vm.Fax;
            updateRequest.HomePage = vm.HomePage;

            ModifySupplierResponse response = _supplierService.ModifySupplier(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(SupplierDetailView vm)
        {
            CreateSupplierRequest request = new CreateSupplierRequest();
            request.CompanyName = vm.CompanyName;
            request.ContactName = vm.ContactName;
            request.ContactTitle = vm.ContactTitle;
            request.Address = vm.Address;
            request.City = vm.City;
            request.Region = vm.Region;
            request.PostalCode = vm.PostalCode;
            request.Country = vm.Country;
            request.Phone = vm.Phone;
            request.Fax = vm.Fax;
            request.HomePage = vm.HomePage;
            CreateSupplierResponse response = _supplierService.CreateSupplier(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveSupplierRequest request = new RemoveSupplierRequest();
            request.SupplierID = id;
            RemoveSupplierResponse response = _supplierService.RemoveSupplier(request);
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

              //                  CreateSupplierRequest request = new CreateSupplierRequest();
             //                   request.SupplierID = csvReader[0];
             //                   request.CompanyName = csvReader[0];
             //                   request.ContactName = csvReader[0];
             //                   request.ContactTitle = csvReader[0];
             //                   request.Address = csvReader[0];
             //                   request.City = csvReader[0];
             //                   request.Region = csvReader[0];
             //                   request.PostalCode = csvReader[0];
             //                   request.Country = csvReader[0];
             //                   request.Phone = csvReader[0];
             //                   request.Fax = csvReader[0];
             //                   request.HomePage = csvReader[0];
             //                 CreateSupplierResponse response = _supplierService.CreateSupplier(request);

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
