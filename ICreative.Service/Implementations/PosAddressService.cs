
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
    public class PosAddressService : IPosAddressService
    {
        private readonly IPosAddressRepository _posAddressRepository;
        private readonly IUnitOfWork _uow;

        public PosAddressService(IPosAddressRepository posAddressRepository,
                               IUnitOfWork uow)
        {
            _posAddressRepository = posAddressRepository;
            _uow = uow;
        }

        public CreatePosAddressResponse CreatePosAddress(CreatePosAddressRequest request)
        {
            CreatePosAddressResponse response = new CreatePosAddressResponse();
            PosAddress posAddress = new PosAddress();

                  posAddress.Address = request.Address;	
                  posAddress.PosMerchants = request.PosMerchants.ConvertToPosMerchants();

            if (posAddress.GetBrokenRules().Count() > 0)
            {
                response.Errors = posAddress.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _posAddressRepository.Add(posAddress);
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


        public GetPosAddressResponse GetPosAddress(GetPosAddressRequest request)
        {
            GetPosAddressResponse response = new GetPosAddressResponse();

            PosAddress posAddress = _posAddressRepository
                                     .FindBy(request.AddressId);

            if (posAddress != null)
            {
                response.PosAddressFound = true;
                response.PosAddress = posAddress.ConvertToPosAddressView();
            }
            else
                response.PosAddressFound = false;


            return response;
        }

        public ModifyPosAddressResponse ModifyPosAddress(ModifyPosAddressRequest request)
        {
            ModifyPosAddressResponse response = new ModifyPosAddressResponse();

            PosAddress posAddress = _posAddressRepository
                                         .FindBy(request.AddressId);

               posAddress.Id = request.AddressId;
                  posAddress.Address = request.Address;	
                  posAddress.PosMerchants = request.PosMerchants.ConvertToPosMerchants();


            if (posAddress.GetBrokenRules().Count() > 0)
            {
                response.Errors = posAddress.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _posAddressRepository.Save(posAddress);
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
        
        public GetAllPosAddressResponse GetAllPosAddresses()
        {
            GetAllPosAddressResponse response = new GetAllPosAddressResponse();

            IEnumerable<PosAddress> posAddresses = _posAddressRepository
                                     .FindAll();

            if (posAddresses != null)
            {
                response.PosAddressFound = true;
                response.PosAddresses = posAddresses.ConvertToPosAddressViews();   
            }
            else
                response.PosAddressFound = false;


            return response;
        } 
        
        
        public RemovePosAddressResponse RemovePosAddress(RemovePosAddressRequest request)
        {
            RemovePosAddressResponse response = new RemovePosAddressResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_posAddressRepository.Remove(request.AddressId) > 0)
	            {
        	        response.PosAddressDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
