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
    public class CustomerTableController : Controller
    {

        private ICustomerService _customerService;    
               
        public CustomerTableController(ICustomerService customerService)
        {
             _customerService = customerService;
        }
 
        public ActionResult Index()
        {
            CustomerTableViewModel model = new CustomerTableViewModel();
            return View("../Datatables/CustomerTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<CustomerFlatViewModel> customers;
            customers = _customerService.GetAllCustomers().Customers.ConvertToCustomerFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = customers.ToList().Count.ToString();
            data.recordsFiltered = customers.ToList().Count.ToString();

            data.data = customers.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.String id)
        {  
            CustomerDetailView vm = new CustomerDetailView();
            GetCustomerRequest request = new GetCustomerRequest();
            request.CustomerID = id;
            GetCustomerResponse response = _customerService.GetCustomer(request);
            if (response.CustomerFound)
                vm = response.Customer.ConvertToCustomerDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(CustomerDetailView vm)
        {
            GetCustomerRequest request = new GetCustomerRequest();
            request.CustomerID = vm.CustomerID;
           
            ModifyCustomerRequest updateRequest = _customerService.GetCustomer(request).Customer.ConvertToModifyCustomerRequest();

            updateRequest.CustomerID = vm.CustomerID;
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

            ModifyCustomerResponse response = _customerService.ModifyCustomer(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(CustomerDetailView vm)
        {
            CreateCustomerRequest request = new CreateCustomerRequest();
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
            CreateCustomerResponse response = _customerService.CreateCustomer(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.String id)
        {
            RemoveCustomerRequest request = new RemoveCustomerRequest();
            request.CustomerID = id;
            RemoveCustomerResponse response = _customerService.RemoveCustomer(request);
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

              //                  CreateCustomerRequest request = new CreateCustomerRequest();
             //                   request.CustomerID = csvReader[0];
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
             //                 CreateCustomerResponse response = _customerService.CreateCustomer(request);

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
