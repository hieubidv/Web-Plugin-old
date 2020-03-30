
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Infrastructure.Domain;
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
using ICreative.Services.Interfaces;
using ICreative.Services.Mapping;
using ICreative.Services.Messaging;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _uow;

        public EmployeeService(IEmployeeRepository employeeRepository,
                               IUnitOfWork uow)
        {
            _employeeRepository = employeeRepository;
            _uow = uow;
        }

        public CreateEmployeeResponse CreateEmployee(CreateEmployeeRequest request)
        {
            CreateEmployeeResponse response = new CreateEmployeeResponse();
            Employee employee = new Employee();

                  employee.LastName = request.LastName;	
                  employee.FirstName = request.FirstName;	
                  employee.Title = request.Title;	
                  employee.TitleOfCourtesy = request.TitleOfCourtesy;	
                  employee.BirthDate = request.BirthDate;	
                  employee.HireDate = request.HireDate;	
                  employee.Address = request.Address;	
                  employee.City = request.City;	
                  employee.Region = request.Region;	
                  employee.PostalCode = request.PostalCode;	
                  employee.Country = request.Country;	
                  employee.HomePhone = request.HomePhone;	
                  employee.Extension = request.Extension;	
                  employee.Photo = request.Photo;	
                  employee.Notes = request.Notes;	
                  employee.PhotoPath = request.PhotoPath;	
                  employee.Territories = request.Territories.ConvertToTerritories();   
                  employee.Orders = request.Orders.ConvertToOrders();
                  employee.EmployeeReference = request.EmployeeReference.ConvertToEmployee();                  

            if (employee.GetBrokenRules().Count() > 0)
            {
                response.Errors = employee.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _employeeRepository.Add(employee);
	            _uow.Commit();  
                    response.Errors = new List<BusinessRule>();
               } catch (Exception ex)
               {
                    List<BusinessRule> errors = new List<BusinessRule>();                    
                    do
                    {
                            errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
                            ex = ex.InnerException;
                    } while (ex != null);

                    response.Errors = errors;
               }
            } 

            return response;
        }


        public GetEmployeeResponse GetEmployee(GetEmployeeRequest request)
        {
            GetEmployeeResponse response = new GetEmployeeResponse();

            Employee employee = _employeeRepository
                                     .FindBy(request.EmployeeID);

            if (employee != null)
            {
                response.EmployeeFound = true;
                response.Employee = employee.ConvertToEmployeeView();
            }
            else
                response.EmployeeFound = false;


            return response;
        }

        public ModifyEmployeeResponse ModifyEmployee(ModifyEmployeeRequest request)
        {
            ModifyEmployeeResponse response = new ModifyEmployeeResponse();

            Employee employee = _employeeRepository
                                         .FindBy(request.EmployeeID);

               employee.Id = request.EmployeeID;
                  employee.LastName = request.LastName;	
                  employee.FirstName = request.FirstName;	
                  employee.Title = request.Title;	
                  employee.TitleOfCourtesy = request.TitleOfCourtesy;	
                  employee.BirthDate = request.BirthDate;	
                  employee.HireDate = request.HireDate;	
                  employee.Address = request.Address;	
                  employee.City = request.City;	
                  employee.Region = request.Region;	
                  employee.PostalCode = request.PostalCode;	
                  employee.Country = request.Country;	
                  employee.HomePhone = request.HomePhone;	
                  employee.Extension = request.Extension;	
                  employee.Photo = request.Photo;	
                  employee.Notes = request.Notes;	
                  employee.PhotoPath = request.PhotoPath;	
                  employee.Territories = request.Territories.ConvertToTerritories();   
                  employee.Orders = request.Orders.ConvertToOrders();
                  employee.EmployeeReference = request.EmployeeReference.ConvertToEmployee();                  


            if (employee.GetBrokenRules().Count() > 0)
            {
                response.Errors = employee.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _employeeRepository.Save(employee);
        	        _uow.Commit();
                        response.Errors = new List<BusinessRule>();
                } catch (Exception ex)
                {
	            response.Errors = new List<BusinessRule>();
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
                }                           
            }           


            return response;
        }
        
        public GetAllEmployeeResponse GetAllEmployees()
        {
            GetAllEmployeeResponse response = new GetAllEmployeeResponse();

            IEnumerable<Employee> employees = _employeeRepository
                                     .FindAll();

            if (employees != null)
            {
                response.EmployeeFound = true;
                response.Employees = employees.ConvertToEmployeeViews();   
            }
            else
                response.EmployeeFound = false;


            return response;
        } 
        
        
        public RemoveEmployeeResponse RemoveEmployee(RemoveEmployeeRequest request)
        {
            RemoveEmployeeResponse response = new RemoveEmployeeResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_employeeRepository.Remove(request.EmployeeID) > 0)
	            {
        	        response.EmployeeDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
