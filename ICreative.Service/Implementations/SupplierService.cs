
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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _uow;

        public SupplierService(ISupplierRepository supplierRepository,
                               IUnitOfWork uow)
        {
            _supplierRepository = supplierRepository;
            _uow = uow;
        }

        public CreateSupplierResponse CreateSupplier(CreateSupplierRequest request)
        {
            CreateSupplierResponse response = new CreateSupplierResponse();
            Supplier supplier = new Supplier();

                  supplier.CompanyName = request.CompanyName;	
                  supplier.ContactName = request.ContactName;	
                  supplier.ContactTitle = request.ContactTitle;	
                  supplier.Address = request.Address;	
                  supplier.City = request.City;	
                  supplier.Region = request.Region;	
                  supplier.PostalCode = request.PostalCode;	
                  supplier.Country = request.Country;	
                  supplier.Phone = request.Phone;	
                  supplier.Fax = request.Fax;	
                  supplier.HomePage = request.HomePage;	
                  supplier.Products = request.Products.ConvertToProducts();

            if (supplier.GetBrokenRules().Count() > 0)
            {
                response.Errors = supplier.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _supplierRepository.Add(supplier);
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


        public GetSupplierResponse GetSupplier(GetSupplierRequest request)
        {
            GetSupplierResponse response = new GetSupplierResponse();

            Supplier supplier = _supplierRepository
                                     .FindBy(request.SupplierID);

            if (supplier != null)
            {
                response.SupplierFound = true;
                response.Supplier = supplier.ConvertToSupplierView();
            }
            else
                response.SupplierFound = false;


            return response;
        }

        public ModifySupplierResponse ModifySupplier(ModifySupplierRequest request)
        {
            ModifySupplierResponse response = new ModifySupplierResponse();

            Supplier supplier = _supplierRepository
                                         .FindBy(request.SupplierID);

               supplier.Id = request.SupplierID;
                  supplier.CompanyName = request.CompanyName;	
                  supplier.ContactName = request.ContactName;	
                  supplier.ContactTitle = request.ContactTitle;	
                  supplier.Address = request.Address;	
                  supplier.City = request.City;	
                  supplier.Region = request.Region;	
                  supplier.PostalCode = request.PostalCode;	
                  supplier.Country = request.Country;	
                  supplier.Phone = request.Phone;	
                  supplier.Fax = request.Fax;	
                  supplier.HomePage = request.HomePage;	
                  supplier.Products = request.Products.ConvertToProducts();


            if (supplier.GetBrokenRules().Count() > 0)
            {
                response.Errors = supplier.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _supplierRepository.Save(supplier);
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
        
        public GetAllSupplierResponse GetAllSuppliers()
        {
            GetAllSupplierResponse response = new GetAllSupplierResponse();

            IEnumerable<Supplier> suppliers = _supplierRepository
                                     .FindAll();

            if (suppliers != null)
            {
                response.SupplierFound = true;
                response.Suppliers = suppliers.ConvertToSupplierViews();   
            }
            else
                response.SupplierFound = false;


            return response;
        } 
        
        
        public RemoveSupplierResponse RemoveSupplier(RemoveSupplierRequest request)
        {
            RemoveSupplierResponse response = new RemoveSupplierResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_supplierRepository.Remove(request.SupplierID) > 0)
	            {
        	        response.SupplierDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
