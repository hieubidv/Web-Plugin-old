
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
    public class PosReceiptOfDeliveryService : IPosReceiptOfDeliveryService
    {
        private readonly IPosReceiptOfDeliveryRepository _posReceiptOfDeliveryRepository;
        private readonly IUnitOfWork _uow;

        public PosReceiptOfDeliveryService(IPosReceiptOfDeliveryRepository posReceiptOfDeliveryRepository,
                               IUnitOfWork uow)
        {
            _posReceiptOfDeliveryRepository = posReceiptOfDeliveryRepository;
            _uow = uow;
        }

        public CreatePosReceiptOfDeliveryResponse CreatePosReceiptOfDelivery(CreatePosReceiptOfDeliveryRequest request)
        {
            CreatePosReceiptOfDeliveryResponse response = new CreatePosReceiptOfDeliveryResponse();
            PosReceiptOfDelivery posReceiptOfDelivery = new PosReceiptOfDelivery();

                  posReceiptOfDelivery.DeliveryDate = request.DeliveryDate;	
                  posReceiptOfDelivery.ReceiverName = request.ReceiverName;	
                  posReceiptOfDelivery.PosTerminals = request.PosTerminals.ConvertToPosTerminals();   
                  posReceiptOfDelivery.User = request.User.ConvertToUser();                  

            if (posReceiptOfDelivery.GetBrokenRules().Count() > 0)
            {
                response.Errors = posReceiptOfDelivery.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _posReceiptOfDeliveryRepository.Add(posReceiptOfDelivery);
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


        public GetPosReceiptOfDeliveryResponse GetPosReceiptOfDelivery(GetPosReceiptOfDeliveryRequest request)
        {
            GetPosReceiptOfDeliveryResponse response = new GetPosReceiptOfDeliveryResponse();

            PosReceiptOfDelivery posReceiptOfDelivery = _posReceiptOfDeliveryRepository
                                     .FindBy(request.PosReceiptOfDeliveryId);

            if (posReceiptOfDelivery != null)
            {
                response.PosReceiptOfDeliveryFound = true;
                response.PosReceiptOfDelivery = posReceiptOfDelivery.ConvertToPosReceiptOfDeliveryView();
            }
            else
                response.PosReceiptOfDeliveryFound = false;


            return response;
        }

        public ModifyPosReceiptOfDeliveryResponse ModifyPosReceiptOfDelivery(ModifyPosReceiptOfDeliveryRequest request)
        {
            ModifyPosReceiptOfDeliveryResponse response = new ModifyPosReceiptOfDeliveryResponse();

            PosReceiptOfDelivery posReceiptOfDelivery = _posReceiptOfDeliveryRepository
                                         .FindBy(request.PosReceiptOfDeliveryId);

               posReceiptOfDelivery.Id = request.PosReceiptOfDeliveryId;
                  posReceiptOfDelivery.DeliveryDate = request.DeliveryDate;	
                  posReceiptOfDelivery.ReceiverName = request.ReceiverName;	
                  posReceiptOfDelivery.PosTerminals = request.PosTerminals.ConvertToPosTerminals();   
                  posReceiptOfDelivery.User = request.User.ConvertToUser();                  


            if (posReceiptOfDelivery.GetBrokenRules().Count() > 0)
            {
                response.Errors = posReceiptOfDelivery.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _posReceiptOfDeliveryRepository.Save(posReceiptOfDelivery);
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
        
        public GetAllPosReceiptOfDeliveryResponse GetAllPosReceiptOfDeliveries()
        {
            GetAllPosReceiptOfDeliveryResponse response = new GetAllPosReceiptOfDeliveryResponse();

            IEnumerable<PosReceiptOfDelivery> posReceiptOfDeliveries = _posReceiptOfDeliveryRepository
                                     .FindAll();

            if (posReceiptOfDeliveries != null)
            {
                response.PosReceiptOfDeliveryFound = true;
                response.PosReceiptOfDeliveries = posReceiptOfDeliveries.ConvertToPosReceiptOfDeliveryViews();   
            }
            else
                response.PosReceiptOfDeliveryFound = false;


            return response;
        } 
        
        
        public RemovePosReceiptOfDeliveryResponse RemovePosReceiptOfDelivery(RemovePosReceiptOfDeliveryRequest request)
        {
            RemovePosReceiptOfDeliveryResponse response = new RemovePosReceiptOfDeliveryResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_posReceiptOfDeliveryRepository.Remove(request.PosReceiptOfDeliveryId) > 0)
	            {
        	        response.PosReceiptOfDeliveryDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
