using ICreative.Controllers.Datatables;
using ICreative.Controllers.Mapping;
using ICreative.Controllers.ViewModels;
using ICreative.Services.Interfaces;
using ICreative.Services.Messaging;
using ICreative.Services.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ICreative.Controllers.Controllers
{
    public class CustomerDemographicDetailController : Controller
    {
        private ICustomerDemographicService _customerDemographicService;    
               
        public CustomerDemographicDetailController(ICustomerDemographicService customerDemographicService)
        {
             _customerDemographicService = customerDemographicService;
        }
        
                
 
        public ActionResult Detail(System.String id)
        {
            return View("../Details/CustomerDemographicDetail", id);
        }

        public JsonResult GetCustomerDemographic(System.String id)
        {
            DataTableViewModel data1;

            GetCustomerDemographicRequest request = new GetCustomerDemographicRequest();
            request.CustomerTypeID = id;
            DetailCustomerDemographic_CustomerDemographicDetailView data = _customerDemographicService.GetCustomerDemographic(request).CustomerDemographic.ConvertToDetailCustomerDemographic_CustomerDemographicDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetCustomerDataTable(System.String id)
        {
            DataTableViewModel data;

            GetCustomerDemographicRequest request = new GetCustomerDemographicRequest();
            request.CustomerTypeID = id;
            CustomerDemographicView customerDemographic = _customerDemographicService.GetCustomerDemographic(request).CustomerDemographic;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = customerDemographic.Customers.ToList().Count.ToString();
            data.recordsFiltered = customerDemographic.Customers.ToList().Count.ToString();

            data.data = customerDemographic.Customers.ConvertToDetailCustomerDemographicCustomerDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
