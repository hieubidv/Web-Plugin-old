
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
    public class PosReceiptOfTestingService : IPosReceiptOfTestingService
    {
        private readonly IPosReceiptOfTestingRepository _posReceiptOfTestingRepository;
        private readonly IUnitOfWork _uow;

        public PosReceiptOfTestingService(IPosReceiptOfTestingRepository posReceiptOfTestingRepository,
                               IUnitOfWork uow)
        {
            _posReceiptOfTestingRepository = posReceiptOfTestingRepository;
            _uow = uow;
        }

        public CreatePosReceiptOfTestingResponse CreatePosReceiptOfTesting(CreatePosReceiptOfTestingRequest request)
        {
            CreatePosReceiptOfTestingResponse response = new CreatePosReceiptOfTestingResponse();
            PosReceiptOfTesting posReceiptOfTesting = new PosReceiptOfTesting();

                  posReceiptOfTesting.TestDate = request.TestDate;	
                  posReceiptOfTesting.AgentAName = request.AgentAName;	
                  posReceiptOfTesting.AgentBName = request.AgentBName;	
                  posReceiptOfTesting.PosId = request.PosId;	
                  posReceiptOfTesting.PosTerminals = request.PosTerminals.ConvertToPosTerminals();   
                  posReceiptOfTesting.PosMerchant = request.PosMerchant.ConvertToPosMerchant();                  

            if (posReceiptOfTesting.GetBrokenRules().Count() > 0)
            {
                response.Errors = posReceiptOfTesting.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _posReceiptOfTestingRepository.Add(posReceiptOfTesting);
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


        public GetPosReceiptOfTestingResponse GetPosReceiptOfTesting(GetPosReceiptOfTestingRequest request)
        {
            GetPosReceiptOfTestingResponse response = new GetPosReceiptOfTestingResponse();

            PosReceiptOfTesting posReceiptOfTesting = _posReceiptOfTestingRepository
                                     .FindBy(request.ReceiptOfTestingId);

            if (posReceiptOfTesting != null)
            {
                response.PosReceiptOfTestingFound = true;
                response.PosReceiptOfTesting = posReceiptOfTesting.ConvertToPosReceiptOfTestingView();
            }
            else
                response.PosReceiptOfTestingFound = false;


            return response;
        }

        public ModifyPosReceiptOfTestingResponse ModifyPosReceiptOfTesting(ModifyPosReceiptOfTestingRequest request)
        {
            ModifyPosReceiptOfTestingResponse response = new ModifyPosReceiptOfTestingResponse();

            PosReceiptOfTesting posReceiptOfTesting = _posReceiptOfTestingRepository
                                         .FindBy(request.ReceiptOfTestingId);

               posReceiptOfTesting.Id = request.ReceiptOfTestingId;
                  posReceiptOfTesting.TestDate = request.TestDate;	
                  posReceiptOfTesting.AgentAName = request.AgentAName;	
                  posReceiptOfTesting.AgentBName = request.AgentBName;	
                  posReceiptOfTesting.PosId = request.PosId;	
                  posReceiptOfTesting.PosTerminals = request.PosTerminals.ConvertToPosTerminals();   
                  posReceiptOfTesting.PosMerchant = request.PosMerchant.ConvertToPosMerchant();                  


            if (posReceiptOfTesting.GetBrokenRules().Count() > 0)
            {
                response.Errors = posReceiptOfTesting.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _posReceiptOfTestingRepository.Save(posReceiptOfTesting);
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
        
        public GetAllPosReceiptOfTestingResponse GetAllPosReceiptOfTestings()
        {
            GetAllPosReceiptOfTestingResponse response = new GetAllPosReceiptOfTestingResponse();

            IEnumerable<PosReceiptOfTesting> posReceiptOfTestings = _posReceiptOfTestingRepository
                                     .FindAll();

            if (posReceiptOfTestings != null)
            {
                response.PosReceiptOfTestingFound = true;
                response.PosReceiptOfTestings = posReceiptOfTestings.ConvertToPosReceiptOfTestingViews();   
            }
            else
                response.PosReceiptOfTestingFound = false;


            return response;
        } 
        
        
        public RemovePosReceiptOfTestingResponse RemovePosReceiptOfTesting(RemovePosReceiptOfTestingRequest request)
        {
            RemovePosReceiptOfTestingResponse response = new RemovePosReceiptOfTestingResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_posReceiptOfTestingRepository.Remove(request.ReceiptOfTestingId) > 0)
	            {
        	        response.PosReceiptOfTestingDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
