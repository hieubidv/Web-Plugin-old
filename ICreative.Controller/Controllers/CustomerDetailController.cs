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
    public class CustomerDetailController : Controller
    {
        private ICustomerService _customerService;    
               
        public CustomerDetailController(ICustomerService customerService)
        {
             _customerService = customerService;
        }
        
                
 
        public ActionResult Detail(System.String id)
        {
            return View("../Details/CustomerDetail", id);
        }

        public JsonResult GetCustomer(System.String id)
        {
            DataTableViewModel data1;

            GetCustomerRequest request = new GetCustomerRequest();
            request.CustomerID = id;
            DetailCustomer_CustomerDetailView data = _customerService.GetCustomer(request).Customer.ConvertToDetailCustomer_CustomerDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetCustomerDemographicDataTable(System.String id)
        {
            DataTableViewModel data;

            GetCustomerRequest request = new GetCustomerRequest();
            request.CustomerID = id;
            CustomerView customer = _customerService.GetCustomer(request).Customer;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = customer.CustomerDemographics.ToList().Count.ToString();
            data.recordsFiltered = customer.CustomerDemographics.ToList().Count.ToString();

            data.data = customer.CustomerDemographics.ConvertToDetailCustomerCustomerDemographicDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOrderDataTable(System.String id)
        {
            DataTableViewModel data;

            GetCustomerRequest request = new GetCustomerRequest();
            request.CustomerID = id;
            CustomerView customer = _customerService.GetCustomer(request).Customer;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = customer.Orders.ToList().Count.ToString();
            data.recordsFiltered = customer.Orders.ToList().Count.ToString();

            data.data = customer.Orders.ConvertToDetailCustomerOrderDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
