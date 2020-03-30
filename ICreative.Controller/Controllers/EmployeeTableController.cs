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
    public class EmployeeTableController : Controller
    {

        private IEmployeeService _employeeService;    
               
        public EmployeeTableController(IEmployeeService employeeService)
        {
             _employeeService = employeeService;
        }
 
        public ActionResult Index()
        {
            EmployeeTableViewModel model = new EmployeeTableViewModel();
            model.Employees = _employeeService.GetAllEmployees().Employees.Select(u=>new SelectListItem() { Text = u.LastName, Value = u.EmployeeID.ToString()}).ToList();
            return View("../Datatables/EmployeeTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<EmployeeFlatViewModel> employees;
            employees = _employeeService.GetAllEmployees().Employees.ConvertToEmployeeFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = employees.ToList().Count.ToString();
            data.recordsFiltered = employees.ToList().Count.ToString();

            data.data = employees.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            EmployeeDetailView vm = new EmployeeDetailView();
            GetEmployeeRequest request = new GetEmployeeRequest();
            request.EmployeeID = id;
            GetEmployeeResponse response = _employeeService.GetEmployee(request);
            if (response.EmployeeFound)
                vm = response.Employee.ConvertToEmployeeDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(EmployeeDetailView vm)
        {
            GetEmployeeRequest request = new GetEmployeeRequest();
            request.EmployeeID = vm.EmployeeID;
           
            ModifyEmployeeRequest updateRequest = _employeeService.GetEmployee(request).Employee.ConvertToModifyEmployeeRequest();

            updateRequest.EmployeeID = vm.EmployeeID;
            updateRequest.LastName = vm.LastName;
            updateRequest.FirstName = vm.FirstName;
            updateRequest.Title = vm.Title;
            updateRequest.TitleOfCourtesy = vm.TitleOfCourtesy;
            updateRequest.BirthDate = vm.BirthDate;
            updateRequest.HireDate = vm.HireDate;
            updateRequest.Address = vm.Address;
            updateRequest.City = vm.City;
            updateRequest.Region = vm.Region;
            updateRequest.PostalCode = vm.PostalCode;
            updateRequest.Country = vm.Country;
            updateRequest.HomePhone = vm.HomePhone;
            updateRequest.Extension = vm.Extension;
            updateRequest.Photo = vm.Photo;
            updateRequest.Notes = vm.Notes;
               GetEmployeeRequest employeeRequest = new GetEmployeeRequest();
            employeeRequest.EmployeeID = vm.EmployeeReferenceEmployeeID;
            updateRequest.EmployeeReference = _employeeService.GetEmployee(employeeRequest).Employee;            
            updateRequest.PhotoPath = vm.PhotoPath;

            ModifyEmployeeResponse response = _employeeService.ModifyEmployee(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(EmployeeDetailView vm)
        {
            CreateEmployeeRequest request = new CreateEmployeeRequest();
            request.LastName = vm.LastName;
            request.FirstName = vm.FirstName;
            request.Title = vm.Title;
            request.TitleOfCourtesy = vm.TitleOfCourtesy;
            request.BirthDate = vm.BirthDate;
            request.HireDate = vm.HireDate;
            request.Address = vm.Address;
            request.City = vm.City;
            request.Region = vm.Region;
            request.PostalCode = vm.PostalCode;
            request.Country = vm.Country;
            request.HomePhone = vm.HomePhone;
            request.Extension = vm.Extension;
            request.Photo = vm.Photo;
            request.Notes = vm.Notes;
               GetEmployeeRequest employeeRequest = new GetEmployeeRequest();
            employeeRequest.EmployeeID = vm.EmployeeReferenceEmployeeID;
            request.EmployeeReference = _employeeService.GetEmployee(employeeRequest).Employee;            
            request.PhotoPath = vm.PhotoPath;
            CreateEmployeeResponse response = _employeeService.CreateEmployee(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveEmployeeRequest request = new RemoveEmployeeRequest();
            request.EmployeeID = id;
            RemoveEmployeeResponse response = _employeeService.RemoveEmployee(request);
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

              //                  CreateEmployeeRequest request = new CreateEmployeeRequest();
             //                   request.EmployeeID = csvReader[0];
             //                   request.LastName = csvReader[0];
             //                   request.FirstName = csvReader[0];
             //                   request.Title = csvReader[0];
             //                   request.TitleOfCourtesy = csvReader[0];
             //                   request.BirthDate = csvReader[0];
             //                   request.HireDate = csvReader[0];
             //                   request.Address = csvReader[0];
             //                   request.City = csvReader[0];
             //                   request.Region = csvReader[0];
             //                   request.PostalCode = csvReader[0];
             //                   request.Country = csvReader[0];
             //                   request.HomePhone = csvReader[0];
             //                   request.Extension = csvReader[0];
             //                   request.Photo = csvReader[0];
             //                   request.Notes = csvReader[0];
             //                   request.EmployeeReferenceEmployeeID = csvReader[0];
             //                   request.PhotoPath = csvReader[0];
             //                 CreateEmployeeResponse response = _employeeService.CreateEmployee(request);

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
