
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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;

        public CustomerService(ICustomerRepository customerRepository,
                               IUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public CreateCustomerResponse CreateCustomer(CreateCustomerRequest request)
        {
            CreateCustomerResponse response = new CreateCustomerResponse();
            Customer customer = new Customer();

                  customer.CompanyName = request.CompanyName;	
                  customer.ContactName = request.ContactName;	
                  customer.ContactTitle = request.ContactTitle;	
                  customer.Address = request.Address;	
                  customer.City = request.City;	
                  customer.Region = request.Region;	
                  customer.PostalCode = request.PostalCode;	
                  customer.Country = request.Country;	
                  customer.Phone = request.Phone;	
                  customer.Fax = request.Fax;	
                  customer.CustomerDemographics = request.CustomerDemographics.ConvertToCustomerDemographics();   
                  customer.Orders = request.Orders.ConvertToOrders();

            if (customer.GetBrokenRules().Count() > 0)
            {
                response.Errors = customer.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _customerRepository.Add(customer);
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


        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            GetCustomerResponse response = new GetCustomerResponse();

            Customer customer = _customerRepository
                                     .FindBy(request.CustomerID);

            if (customer != null)
            {
                response.CustomerFound = true;
                response.Customer = customer.ConvertToCustomerView();
            }
            else
                response.CustomerFound = false;


            return response;
        }

        public ModifyCustomerResponse ModifyCustomer(ModifyCustomerRequest request)
        {
            ModifyCustomerResponse response = new ModifyCustomerResponse();

            Customer customer = _customerRepository
                                         .FindBy(request.CustomerID);

               customer.Id = request.CustomerID;
                  customer.CompanyName = request.CompanyName;	
                  customer.ContactName = request.ContactName;	
                  customer.ContactTitle = request.ContactTitle;	
                  customer.Address = request.Address;	
                  customer.City = request.City;	
                  customer.Region = request.Region;	
                  customer.PostalCode = request.PostalCode;	
                  customer.Country = request.Country;	
                  customer.Phone = request.Phone;	
                  customer.Fax = request.Fax;	
                  customer.CustomerDemographics = request.CustomerDemographics.ConvertToCustomerDemographics();   
                  customer.Orders = request.Orders.ConvertToOrders();


            if (customer.GetBrokenRules().Count() > 0)
            {
                response.Errors = customer.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _customerRepository.Save(customer);
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
        
        public GetAllCustomerResponse GetAllCustomers()
        {
            GetAllCustomerResponse response = new GetAllCustomerResponse();

            IEnumerable<Customer> customers = _customerRepository
                                     .FindAll();

            if (customers != null)
            {
                response.CustomerFound = true;
                response.Customers = customers.ConvertToCustomerViews();   
            }
            else
                response.CustomerFound = false;


            return response;
        } 
        
        
        public RemoveCustomerResponse RemoveCustomer(RemoveCustomerRequest request)
        {
            RemoveCustomerResponse response = new RemoveCustomerResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_customerRepository.Remove(request.CustomerID) > 0)
	            {
        	        response.CustomerDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
