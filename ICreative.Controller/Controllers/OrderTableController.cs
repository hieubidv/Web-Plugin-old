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
    public class OrderTableController : Controller
    {

        private ICustomerService _customerService;
private IEmployeeService _employeeService;
private IOrderService _orderService;
private IShipperService _shipperService;    
               
        public OrderTableController(ICustomerService customerService,IEmployeeService employeeService,IOrderService orderService,IShipperService shipperService)
        {
             _customerService = customerService;
_employeeService = employeeService;
_orderService = orderService;
_shipperService = shipperService;
        }
 
        public ActionResult Index()
        {
            OrderTableViewModel model = new OrderTableViewModel();
            model.Employees = _employeeService.GetAllEmployees().Employees.Select(u=>new SelectListItem() { Text = u.LastName, Value = u.EmployeeID.ToString()}).ToList();
            model.Customers = _customerService.GetAllCustomers().Customers.Select(u=>new SelectListItem() { Text = u.CompanyName, Value = u.CustomerID}).ToList();
            model.Shippers = _shipperService.GetAllShippers().Shippers.Select(u=>new SelectListItem() { Text = u.CompanyName, Value = u.ShipperID.ToString()}).ToList();
            return View("../Datatables/OrderTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<OrderFlatViewModel> orders;
            orders = _orderService.GetAllOrders().Orders.ConvertToOrderFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = orders.ToList().Count.ToString();
            data.recordsFiltered = orders.ToList().Count.ToString();

            data.data = orders.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            OrderDetailView vm = new OrderDetailView();
            GetOrderRequest request = new GetOrderRequest();
            request.OrderID = id;
            GetOrderResponse response = _orderService.GetOrder(request);
            if (response.OrderFound)
                vm = response.Order.ConvertToOrderDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(OrderDetailView vm)
        {
            GetOrderRequest request = new GetOrderRequest();
            request.OrderID = vm.OrderID;
           
            ModifyOrderRequest updateRequest = _orderService.GetOrder(request).Order.ConvertToModifyOrderRequest();

            updateRequest.OrderID = vm.OrderID;
               GetCustomerRequest customerRequest = new GetCustomerRequest();
            customerRequest.CustomerID = vm.CustomerCustomerID;
            updateRequest.Customer = _customerService.GetCustomer(customerRequest).Customer;            
               GetEmployeeRequest employeeRequest = new GetEmployeeRequest();
            employeeRequest.EmployeeID = vm.EmployeeEmployeeID;
            updateRequest.Employee = _employeeService.GetEmployee(employeeRequest).Employee;            
            updateRequest.OrderDate = vm.OrderDate;
            updateRequest.RequiredDate = vm.RequiredDate;
            updateRequest.ShippedDate = vm.ShippedDate;
               GetShipperRequest shipperRequest = new GetShipperRequest();
            shipperRequest.ShipperID = vm.ShipperShipperID;
            updateRequest.Shipper = _shipperService.GetShipper(shipperRequest).Shipper;            
            updateRequest.Freight = vm.Freight;
            updateRequest.ShipName = vm.ShipName;
            updateRequest.ShipAddress = vm.ShipAddress;
            updateRequest.ShipCity = vm.ShipCity;
            updateRequest.ShipRegion = vm.ShipRegion;
            updateRequest.ShipPostalCode = vm.ShipPostalCode;
            updateRequest.ShipCountry = vm.ShipCountry;

            ModifyOrderResponse response = _orderService.ModifyOrder(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(OrderDetailView vm)
        {
            CreateOrderRequest request = new CreateOrderRequest();
               GetCustomerRequest customerRequest = new GetCustomerRequest();
            customerRequest.CustomerID = vm.CustomerCustomerID;
            request.Customer = _customerService.GetCustomer(customerRequest).Customer;            
               GetEmployeeRequest employeeRequest = new GetEmployeeRequest();
            employeeRequest.EmployeeID = vm.EmployeeEmployeeID;
            request.Employee = _employeeService.GetEmployee(employeeRequest).Employee;            
            request.OrderDate = vm.OrderDate;
            request.RequiredDate = vm.RequiredDate;
            request.ShippedDate = vm.ShippedDate;
               GetShipperRequest shipperRequest = new GetShipperRequest();
            shipperRequest.ShipperID = vm.ShipperShipperID;
            request.Shipper = _shipperService.GetShipper(shipperRequest).Shipper;            
            request.Freight = vm.Freight;
            request.ShipName = vm.ShipName;
            request.ShipAddress = vm.ShipAddress;
            request.ShipCity = vm.ShipCity;
            request.ShipRegion = vm.ShipRegion;
            request.ShipPostalCode = vm.ShipPostalCode;
            request.ShipCountry = vm.ShipCountry;
            CreateOrderResponse response = _orderService.CreateOrder(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveOrderRequest request = new RemoveOrderRequest();
            request.OrderID = id;
            RemoveOrderResponse response = _orderService.RemoveOrder(request);
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

              //                  CreateOrderRequest request = new CreateOrderRequest();
             //                   request.OrderID = csvReader[0];
             //                   request.CustomerCustomerID = csvReader[0];
             //                   request.EmployeeEmployeeID = csvReader[0];
             //                   request.OrderDate = csvReader[0];
             //                   request.RequiredDate = csvReader[0];
             //                   request.ShippedDate = csvReader[0];
             //                   request.ShipperShipperID = csvReader[0];
             //                   request.Freight = csvReader[0];
             //                   request.ShipName = csvReader[0];
             //                   request.ShipAddress = csvReader[0];
             //                   request.ShipCity = csvReader[0];
             //                   request.ShipRegion = csvReader[0];
             //                   request.ShipPostalCode = csvReader[0];
             //                   request.ShipCountry = csvReader[0];
             //                 CreateOrderResponse response = _orderService.CreateOrder(request);

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
