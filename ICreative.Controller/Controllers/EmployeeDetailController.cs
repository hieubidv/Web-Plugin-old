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
    public class EmployeeDetailController : Controller
    {
        private IEmployeeService _employeeService;    
               
        public EmployeeDetailController(IEmployeeService employeeService)
        {
             _employeeService = employeeService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/EmployeeDetail", id);
        }

        public JsonResult GetEmployee(System.Int32 id)
        {
            DataTableViewModel data1;

            GetEmployeeRequest request = new GetEmployeeRequest();
            request.EmployeeID = id;
            DetailEmployee_EmployeeDetailView data = _employeeService.GetEmployee(request).Employee.ConvertToDetailEmployee_EmployeeDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetTerritoryDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetEmployeeRequest request = new GetEmployeeRequest();
            request.EmployeeID = id;
            EmployeeView employee = _employeeService.GetEmployee(request).Employee;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = employee.Territories.ToList().Count.ToString();
            data.recordsFiltered = employee.Territories.ToList().Count.ToString();

            data.data = employee.Territories.ConvertToDetailEmployeeTerritoryDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOrderDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetEmployeeRequest request = new GetEmployeeRequest();
            request.EmployeeID = id;
            EmployeeView employee = _employeeService.GetEmployee(request).Employee;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = employee.Orders.ToList().Count.ToString();
            data.recordsFiltered = employee.Orders.ToList().Count.ToString();

            data.data = employee.Orders.ConvertToDetailEmployeeOrderDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
