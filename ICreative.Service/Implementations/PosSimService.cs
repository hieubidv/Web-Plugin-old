
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
    public class PosSimService : IPosSimService
    {
        private readonly IPosSimRepository _posSimRepository;
        private readonly IUnitOfWork _uow;

        public PosSimService(IPosSimRepository posSimRepository,
                               IUnitOfWork uow)
        {
            _posSimRepository = posSimRepository;
            _uow = uow;
        }

        public CreatePosSimResponse CreatePosSim(CreatePosSimRequest request)
        {
            CreatePosSimResponse response = new CreatePosSimResponse();
            PosSim posSim = new PosSim();

                  posSim.SimCode = request.SimCode;	
                  posSim.SimPhoneNumber = request.SimPhoneNumber;	
                  posSim.AddedDate = request.AddedDate;	
                  posSim.PosTerminals = request.PosTerminals.ConvertToPosTerminals();
                  posSim.PosStatusSim = request.PosStatusSim.ConvertToPosStatusSim();                  
                  posSim.PosSimProvider = request.PosSimProvider.ConvertToPosSimProvider();                  

            if (posSim.GetBrokenRules().Count() > 0)
            {
                response.Errors = posSim.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _posSimRepository.Add(posSim);
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


        public GetPosSimResponse GetPosSim(GetPosSimRequest request)
        {
            GetPosSimResponse response = new GetPosSimResponse();

            PosSim posSim = _posSimRepository
                                     .FindBy(request.SimId);

            if (posSim != null)
            {
                response.PosSimFound = true;
                response.PosSim = posSim.ConvertToPosSimView();
            }
            else
                response.PosSimFound = false;


            return response;
        }

        public ModifyPosSimResponse ModifyPosSim(ModifyPosSimRequest request)
        {
            ModifyPosSimResponse response = new ModifyPosSimResponse();

            PosSim posSim = _posSimRepository
                                         .FindBy(request.SimId);

               posSim.Id = request.SimId;
                  posSim.SimCode = request.SimCode;	
                  posSim.SimPhoneNumber = request.SimPhoneNumber;	
                  posSim.AddedDate = request.AddedDate;	
                  posSim.PosTerminals = request.PosTerminals.ConvertToPosTerminals();
                  posSim.PosStatusSim = request.PosStatusSim.ConvertToPosStatusSim();                  
                  posSim.PosSimProvider = request.PosSimProvider.ConvertToPosSimProvider();                  


            if (posSim.GetBrokenRules().Count() > 0)
            {
                response.Errors = posSim.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _posSimRepository.Save(posSim);
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
        
        public GetAllPosSimResponse GetAllPosSims()
        {
            GetAllPosSimResponse response = new GetAllPosSimResponse();

            IEnumerable<PosSim> posSims = _posSimRepository
                                     .FindAll();

            if (posSims != null)
            {
                response.PosSimFound = true;
                response.PosSims = posSims.ConvertToPosSimViews();   
            }
            else
                response.PosSimFound = false;


            return response;
        } 
        
        
        public RemovePosSimResponse RemovePosSim(RemovePosSimRequest request)
        {
            RemovePosSimResponse response = new RemovePosSimResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_posSimRepository.Remove(request.SimId) > 0)
	            {
        	        response.PosSimDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
