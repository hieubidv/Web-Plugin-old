
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
    public class CustomerDemographicService : ICustomerDemographicService
    {
        private readonly ICustomerDemographicRepository _customerDemographicRepository;
        private readonly IUnitOfWork _uow;

        public CustomerDemographicService(ICustomerDemographicRepository customerDemographicRepository,
                               IUnitOfWork uow)
        {
            _customerDemographicRepository = customerDemographicRepository;
            _uow = uow;
        }

        public CreateCustomerDemographicResponse CreateCustomerDemographic(CreateCustomerDemographicRequest request)
        {
            CreateCustomerDemographicResponse response = new CreateCustomerDemographicResponse();
            CustomerDemographic customerDemographic = new CustomerDemographic();

                  customerDemographic.CustomerDesc = request.CustomerDesc;	
                  customerDemographic.Customers = request.Customers.ConvertToCustomers();   

            if (customerDemographic.GetBrokenRules().Count() > 0)
            {
                response.Errors = customerDemographic.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _customerDemographicRepository.Add(customerDemographic);
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


        public GetCustomerDemographicResponse GetCustomerDemographic(GetCustomerDemographicRequest request)
        {
            GetCustomerDemographicResponse response = new GetCustomerDemographicResponse();

            CustomerDemographic customerDemographic = _customerDemographicRepository
                                     .FindBy(request.CustomerTypeID);

            if (customerDemographic != null)
            {
                response.CustomerDemographicFound = true;
                response.CustomerDemographic = customerDemographic.ConvertToCustomerDemographicView();
            }
            else
                response.CustomerDemographicFound = false;


            return response;
        }

        public ModifyCustomerDemographicResponse ModifyCustomerDemographic(ModifyCustomerDemographicRequest request)
        {
            ModifyCustomerDemographicResponse response = new ModifyCustomerDemographicResponse();

            CustomerDemographic customerDemographic = _customerDemographicRepository
                                         .FindBy(request.CustomerTypeID);

               customerDemographic.Id = request.CustomerTypeID;
                  customerDemographic.CustomerDesc = request.CustomerDesc;	
                  customerDemographic.Customers = request.Customers.ConvertToCustomers();   


            if (customerDemographic.GetBrokenRules().Count() > 0)
            {
                response.Errors = customerDemographic.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _customerDemographicRepository.Save(customerDemographic);
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
        
        public GetAllCustomerDemographicResponse GetAllCustomerDemographics()
        {
            GetAllCustomerDemographicResponse response = new GetAllCustomerDemographicResponse();

            IEnumerable<CustomerDemographic> customerDemographics = _customerDemographicRepository
                                     .FindAll();

            if (customerDemographics != null)
            {
                response.CustomerDemographicFound = true;
                response.CustomerDemographics = customerDemographics.ConvertToCustomerDemographicViews();   
            }
            else
                response.CustomerDemographicFound = false;


            return response;
        } 
        
        
        public RemoveCustomerDemographicResponse RemoveCustomerDemographic(RemoveCustomerDemographicRequest request)
        {
            RemoveCustomerDemographicResponse response = new RemoveCustomerDemographicResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_customerDemographicRepository.Remove(request.CustomerTypeID) > 0)
	            {
        	        response.CustomerDemographicDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
