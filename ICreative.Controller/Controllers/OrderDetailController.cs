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
    public class OrderDetailController : Controller
    {
        private ICustomerService _customerService;
private IEmployeeService _employeeService;
private IOrderService _orderService;
private IShipperService _shipperService;    
               
        public OrderDetailController(ICustomerService customerService,IEmployeeService employeeService,IOrderService orderService,IShipperService shipperService)
        {
             _customerService = customerService;
_employeeService = employeeService;
_orderService = orderService;
_shipperService = shipperService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/OrderDetail", id);
        }

        public JsonResult GetOrder(System.Int32 id)
        {
            DataTableViewModel data1;

            GetOrderRequest request = new GetOrderRequest();
            request.OrderID = id;
            DetailOrder_OrderDetailView data = _orderService.GetOrder(request).Order.ConvertToDetailOrder_OrderDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetProductDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetOrderRequest request = new GetOrderRequest();
            request.OrderID = id;
            OrderView order = _orderService.GetOrder(request).Order;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = order.Products.ToList().Count.ToString();
            data.recordsFiltered = order.Products.ToList().Count.ToString();

            data.data = order.Products.ConvertToDetailOrderProductDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
