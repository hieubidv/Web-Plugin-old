
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
    public class PosTerminalService : IPosTerminalService
    {
        private readonly IPosTerminalRepository _posTerminalRepository;
        private readonly IUnitOfWork _uow;

        public PosTerminalService(IPosTerminalRepository posTerminalRepository,
                               IUnitOfWork uow)
        {
            _posTerminalRepository = posTerminalRepository;
            _uow = uow;
        }

        public CreatePosTerminalResponse CreatePosTerminal(CreatePosTerminalRequest request)
        {
            CreatePosTerminalResponse response = new CreatePosTerminalResponse();
            PosTerminal posTerminal = new PosTerminal();

                  posTerminal.TerminalIdByHeadQuater = request.TerminalIdByHeadQuater;	
                  posTerminal.InitializeCode = request.InitializeCode;	
                  posTerminal.ConnectType = request.ConnectType;	
                  posTerminal.PosReceiptOfDeliveries = request.PosReceiptOfDeliveries.ConvertToPosReceiptOfDeliveries();   
                  posTerminal.PosReceiptOfTestings = request.PosReceiptOfTestings.ConvertToPosReceiptOfTestings();   
                  posTerminal.PosDevice = request.PosDevice.ConvertToPosDevice();                  
                  posTerminal.PosStatusTerminal = request.PosStatusTerminal.ConvertToPosStatusTerminal();                  
                  posTerminal.PosSim = request.PosSim.ConvertToPosSim();                  

            if (posTerminal.GetBrokenRules().Count() > 0)
            {
                response.Errors = posTerminal.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _posTerminalRepository.Add(posTerminal);
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


        public GetPosTerminalResponse GetPosTerminal(GetPosTerminalRequest request)
        {
            GetPosTerminalResponse response = new GetPosTerminalResponse();

            PosTerminal posTerminal = _posTerminalRepository
                                     .FindBy(request.TerminalId);

            if (posTerminal != null)
            {
                response.PosTerminalFound = true;
                response.PosTerminal = posTerminal.ConvertToPosTerminalView();
            }
            else
                response.PosTerminalFound = false;


            return response;
        }

        public ModifyPosTerminalResponse ModifyPosTerminal(ModifyPosTerminalRequest request)
        {
            ModifyPosTerminalResponse response = new ModifyPosTerminalResponse();

            PosTerminal posTerminal = _posTerminalRepository
                                         .FindBy(request.TerminalId);

               posTerminal.Id = request.TerminalId;
                  posTerminal.TerminalIdByHeadQuater = request.TerminalIdByHeadQuater;	
                  posTerminal.InitializeCode = request.InitializeCode;	
                  posTerminal.ConnectType = request.ConnectType;	
                  posTerminal.PosReceiptOfDeliveries = request.PosReceiptOfDeliveries.ConvertToPosReceiptOfDeliveries();   
                  posTerminal.PosReceiptOfTestings = request.PosReceiptOfTestings.ConvertToPosReceiptOfTestings();   
                  posTerminal.PosDevice = request.PosDevice.ConvertToPosDevice();                  
                  posTerminal.PosStatusTerminal = request.PosStatusTerminal.ConvertToPosStatusTerminal();                  
                  posTerminal.PosSim = request.PosSim.ConvertToPosSim();                  


            if (posTerminal.GetBrokenRules().Count() > 0)
            {
                response.Errors = posTerminal.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _posTerminalRepository.Save(posTerminal);
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
        
        public GetAllPosTerminalResponse GetAllPosTerminals()
        {
            GetAllPosTerminalResponse response = new GetAllPosTerminalResponse();

            IEnumerable<PosTerminal> posTerminals = _posTerminalRepository
                                     .FindAll();

            if (posTerminals != null)
            {
                response.PosTerminalFound = true;
                response.PosTerminals = posTerminals.ConvertToPosTerminalViews();   
            }
            else
                response.PosTerminalFound = false;


            return response;
        } 
        
        
        public RemovePosTerminalResponse RemovePosTerminal(RemovePosTerminalRequest request)
        {
            RemovePosTerminalResponse response = new RemovePosTerminalResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_posTerminalRepository.Remove(request.TerminalId) > 0)
	            {
        	        response.PosTerminalDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
