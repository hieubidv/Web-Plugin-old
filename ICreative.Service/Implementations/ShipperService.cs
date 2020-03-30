
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
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly IUnitOfWork _uow;

        public ShipperService(IShipperRepository shipperRepository,
                               IUnitOfWork uow)
        {
            _shipperRepository = shipperRepository;
            _uow = uow;
        }

        public CreateShipperResponse CreateShipper(CreateShipperRequest request)
        {
            CreateShipperResponse response = new CreateShipperResponse();
            Shipper shipper = new Shipper();

                  shipper.CompanyName = request.CompanyName;	
                  shipper.Phone = request.Phone;	
                  shipper.Orders = request.Orders.ConvertToOrders();

            if (shipper.GetBrokenRules().Count() > 0)
            {
                response.Errors = shipper.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _shipperRepository.Add(shipper);
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


        public GetShipperResponse GetShipper(GetShipperRequest request)
        {
            GetShipperResponse response = new GetShipperResponse();

            Shipper shipper = _shipperRepository
                                     .FindBy(request.ShipperID);

            if (shipper != null)
            {
                response.ShipperFound = true;
                response.Shipper = shipper.ConvertToShipperView();
            }
            else
                response.ShipperFound = false;


            return response;
        }

        public ModifyShipperResponse ModifyShipper(ModifyShipperRequest request)
        {
            ModifyShipperResponse response = new ModifyShipperResponse();

            Shipper shipper = _shipperRepository
                                         .FindBy(request.ShipperID);

               shipper.Id = request.ShipperID;
                  shipper.CompanyName = request.CompanyName;	
                  shipper.Phone = request.Phone;	
                  shipper.Orders = request.Orders.ConvertToOrders();


            if (shipper.GetBrokenRules().Count() > 0)
            {
                response.Errors = shipper.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _shipperRepository.Save(shipper);
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
        
        public GetAllShipperResponse GetAllShippers()
        {
            GetAllShipperResponse response = new GetAllShipperResponse();

            IEnumerable<Shipper> shippers = _shipperRepository
                                     .FindAll();

            if (shippers != null)
            {
                response.ShipperFound = true;
                response.Shippers = shippers.ConvertToShipperViews();   
            }
            else
                response.ShipperFound = false;


            return response;
        } 
        
        
        public RemoveShipperResponse RemoveShipper(RemoveShipperRequest request)
        {
            RemoveShipperResponse response = new RemoveShipperResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_shipperRepository.Remove(request.ShipperID) > 0)
	            {
        	        response.ShipperDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
