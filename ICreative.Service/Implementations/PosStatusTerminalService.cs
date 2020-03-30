
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
    public class PosStatusTerminalService : IPosStatusTerminalService
    {
        private readonly IPosStatusTerminalRepository _posStatusTerminalRepository;
        private readonly IUnitOfWork _uow;

        public PosStatusTerminalService(IPosStatusTerminalRepository posStatusTerminalRepository,
                               IUnitOfWork uow)
        {
            _posStatusTerminalRepository = posStatusTerminalRepository;
            _uow = uow;
        }

        public CreatePosStatusTerminalResponse CreatePosStatusTerminal(CreatePosStatusTerminalRequest request)
        {
            CreatePosStatusTerminalResponse response = new CreatePosStatusTerminalResponse();
            PosStatusTerminal posStatusTerminal = new PosStatusTerminal();

                  posStatusTerminal.StatusName = request.StatusName;	
                  posStatusTerminal.PosTerminals = request.PosTerminals.ConvertToPosTerminals();

            if (posStatusTerminal.GetBrokenRules().Count() > 0)
            {
                response.Errors = posStatusTerminal.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _posStatusTerminalRepository.Add(posStatusTerminal);
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


        public GetPosStatusTerminalResponse GetPosStatusTerminal(GetPosStatusTerminalRequest request)
        {
            GetPosStatusTerminalResponse response = new GetPosStatusTerminalResponse();

            PosStatusTerminal posStatusTerminal = _posStatusTerminalRepository
                                     .FindBy(request.TerminalStatusId);

            if (posStatusTerminal != null)
            {
                response.PosStatusTerminalFound = true;
                response.PosStatusTerminal = posStatusTerminal.ConvertToPosStatusTerminalView();
            }
            else
                response.PosStatusTerminalFound = false;


            return response;
        }

        public ModifyPosStatusTerminalResponse ModifyPosStatusTerminal(ModifyPosStatusTerminalRequest request)
        {
            ModifyPosStatusTerminalResponse response = new ModifyPosStatusTerminalResponse();

            PosStatusTerminal posStatusTerminal = _posStatusTerminalRepository
                                         .FindBy(request.TerminalStatusId);

               posStatusTerminal.Id = request.TerminalStatusId;
                  posStatusTerminal.StatusName = request.StatusName;	
                  posStatusTerminal.PosTerminals = request.PosTerminals.ConvertToPosTerminals();


            if (posStatusTerminal.GetBrokenRules().Count() > 0)
            {
                response.Errors = posStatusTerminal.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _posStatusTerminalRepository.Save(posStatusTerminal);
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
        
        public GetAllPosStatusTerminalResponse GetAllPosStatusTerminals()
        {
            GetAllPosStatusTerminalResponse response = new GetAllPosStatusTerminalResponse();

            IEnumerable<PosStatusTerminal> posStatusTerminals = _posStatusTerminalRepository
                                     .FindAll();

            if (posStatusTerminals != null)
            {
                response.PosStatusTerminalFound = true;
                response.PosStatusTerminals = posStatusTerminals.ConvertToPosStatusTerminalViews();   
            }
            else
                response.PosStatusTerminalFound = false;


            return response;
        } 
        
        
        public RemovePosStatusTerminalResponse RemovePosStatusTerminal(RemovePosStatusTerminalRequest request)
        {
            RemovePosStatusTerminalResponse response = new RemovePosStatusTerminalResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_posStatusTerminalRepository.Remove(request.TerminalStatusId) > 0)
	            {
        	        response.PosStatusTerminalDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
