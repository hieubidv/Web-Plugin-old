
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
    public class PosDeviceService : IPosDeviceService
    {
        private readonly IPosDeviceRepository _posDeviceRepository;
        private readonly IUnitOfWork _uow;

        public PosDeviceService(IPosDeviceRepository posDeviceRepository,
                               IUnitOfWork uow)
        {
            _posDeviceRepository = posDeviceRepository;
            _uow = uow;
        }

        public CreatePosDeviceResponse CreatePosDevice(CreatePosDeviceRequest request)
        {
            CreatePosDeviceResponse response = new CreatePosDeviceResponse();
            PosDevice posDevice = new PosDevice();

                  posDevice.BrandId = request.BrandId;	
                  posDevice.SerialNumber = request.SerialNumber;	
                  posDevice.Model = request.Model;	
                  posDevice.PosTerminals = request.PosTerminals.ConvertToPosTerminals();

            if (posDevice.GetBrokenRules().Count() > 0)
            {
                response.Errors = posDevice.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _posDeviceRepository.Add(posDevice);
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


        public GetPosDeviceResponse GetPosDevice(GetPosDeviceRequest request)
        {
            GetPosDeviceResponse response = new GetPosDeviceResponse();

            PosDevice posDevice = _posDeviceRepository
                                     .FindBy(request.DeviceId);

            if (posDevice != null)
            {
                response.PosDeviceFound = true;
                response.PosDevice = posDevice.ConvertToPosDeviceView();
            }
            else
                response.PosDeviceFound = false;


            return response;
        }

        public ModifyPosDeviceResponse ModifyPosDevice(ModifyPosDeviceRequest request)
        {
            ModifyPosDeviceResponse response = new ModifyPosDeviceResponse();

            PosDevice posDevice = _posDeviceRepository
                                         .FindBy(request.DeviceId);

               posDevice.Id = request.DeviceId;
                  posDevice.BrandId = request.BrandId;	
                  posDevice.SerialNumber = request.SerialNumber;	
                  posDevice.Model = request.Model;	
                  posDevice.PosTerminals = request.PosTerminals.ConvertToPosTerminals();


            if (posDevice.GetBrokenRules().Count() > 0)
            {
                response.Errors = posDevice.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _posDeviceRepository.Save(posDevice);
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
        
        public GetAllPosDeviceResponse GetAllPosDevices()
        {
            GetAllPosDeviceResponse response = new GetAllPosDeviceResponse();

            IEnumerable<PosDevice> posDevices = _posDeviceRepository
                                     .FindAll();

            if (posDevices != null)
            {
                response.PosDeviceFound = true;
                response.PosDevices = posDevices.ConvertToPosDeviceViews();   
            }
            else
                response.PosDeviceFound = false;


            return response;
        } 
        
        
        public RemovePosDeviceResponse RemovePosDevice(RemovePosDeviceRequest request)
        {
            RemovePosDeviceResponse response = new RemovePosDeviceResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_posDeviceRepository.Remove(request.DeviceId) > 0)
	            {
        	        response.PosDeviceDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
