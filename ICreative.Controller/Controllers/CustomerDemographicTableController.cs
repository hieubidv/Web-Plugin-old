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
    public class CustomerDemographicTableController : Controller
    {

        private ICustomerDemographicService _customerDemographicService;    
               
        public CustomerDemographicTableController(ICustomerDemographicService customerDemographicService)
        {
             _customerDemographicService = customerDemographicService;
        }
 
        public ActionResult Index()
        {
            CustomerDemographicTableViewModel model = new CustomerDemographicTableViewModel();
            return View("../Datatables/CustomerDemographicTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<CustomerDemographicFlatViewModel> customerDemographics;
            customerDemographics = _customerDemographicService.GetAllCustomerDemographics().CustomerDemographics.ConvertToCustomerDemographicFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = customerDemographics.ToList().Count.ToString();
            data.recordsFiltered = customerDemographics.ToList().Count.ToString();

            data.data = customerDemographics.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.String id)
        {  
            CustomerDemographicDetailView vm = new CustomerDemographicDetailView();
            GetCustomerDemographicRequest request = new GetCustomerDemographicRequest();
            request.CustomerTypeID = id;
            GetCustomerDemographicResponse response = _customerDemographicService.GetCustomerDemographic(request);
            if (response.CustomerDemographicFound)
                vm = response.CustomerDemographic.ConvertToCustomerDemographicDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(CustomerDemographicDetailView vm)
        {
            GetCustomerDemographicRequest request = new GetCustomerDemographicRequest();
            request.CustomerTypeID = vm.CustomerTypeID;
           
            ModifyCustomerDemographicRequest updateRequest = _customerDemographicService.GetCustomerDemographic(request).CustomerDemographic.ConvertToModifyCustomerDemographicRequest();

            updateRequest.CustomerTypeID = vm.CustomerTypeID;
            updateRequest.CustomerDesc = vm.CustomerDesc;

            ModifyCustomerDemographicResponse response = _customerDemographicService.ModifyCustomerDemographic(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(CustomerDemographicDetailView vm)
        {
            CreateCustomerDemographicRequest request = new CreateCustomerDemographicRequest();
            request.CustomerDesc = vm.CustomerDesc;
            CreateCustomerDemographicResponse response = _customerDemographicService.CreateCustomerDemographic(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.String id)
        {
            RemoveCustomerDemographicRequest request = new RemoveCustomerDemographicRequest();
            request.CustomerTypeID = id;
            RemoveCustomerDemographicResponse response = _customerDemographicService.RemoveCustomerDemographic(request);
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

              //                  CreateCustomerDemographicRequest request = new CreateCustomerDemographicRequest();
             //                   request.CustomerTypeID = csvReader[0];
             //                   request.CustomerDesc = csvReader[0];
             //                 CreateCustomerDemographicResponse response = _customerDemographicService.CreateCustomerDemographic(request);

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
