
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
    public class PosStatusSimService : IPosStatusSimService
    {
        private readonly IPosStatusSimRepository _posStatusSimRepository;
        private readonly IUnitOfWork _uow;

        public PosStatusSimService(IPosStatusSimRepository posStatusSimRepository,
                               IUnitOfWork uow)
        {
            _posStatusSimRepository = posStatusSimRepository;
            _uow = uow;
        }

        public CreatePosStatusSimResponse CreatePosStatusSim(CreatePosStatusSimRequest request)
        {
            CreatePosStatusSimResponse response = new CreatePosStatusSimResponse();
            PosStatusSim posStatusSim = new PosStatusSim();

                  posStatusSim.StatusName = request.StatusName;	
                  posStatusSim.PosSims = request.PosSims.ConvertToPosSims();

            if (posStatusSim.GetBrokenRules().Count() > 0)
            {
                response.Errors = posStatusSim.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _posStatusSimRepository.Add(posStatusSim);
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


        public GetPosStatusSimResponse GetPosStatusSim(GetPosStatusSimRequest request)
        {
            GetPosStatusSimResponse response = new GetPosStatusSimResponse();

            PosStatusSim posStatusSim = _posStatusSimRepository
                                     .FindBy(request.StatusId);

            if (posStatusSim != null)
            {
                response.PosStatusSimFound = true;
                response.PosStatusSim = posStatusSim.ConvertToPosStatusSimView();
            }
            else
                response.PosStatusSimFound = false;


            return response;
        }

        public ModifyPosStatusSimResponse ModifyPosStatusSim(ModifyPosStatusSimRequest request)
        {
            ModifyPosStatusSimResponse response = new ModifyPosStatusSimResponse();

            PosStatusSim posStatusSim = _posStatusSimRepository
                                         .FindBy(request.StatusId);

               posStatusSim.Id = request.StatusId;
                  posStatusSim.StatusName = request.StatusName;	
                  posStatusSim.PosSims = request.PosSims.ConvertToPosSims();


            if (posStatusSim.GetBrokenRules().Count() > 0)
            {
                response.Errors = posStatusSim.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _posStatusSimRepository.Save(posStatusSim);
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
        
        public GetAllPosStatusSimResponse GetAllPosStatusSims()
        {
            GetAllPosStatusSimResponse response = new GetAllPosStatusSimResponse();

            IEnumerable<PosStatusSim> posStatusSims = _posStatusSimRepository
                                     .FindAll();

            if (posStatusSims != null)
            {
                response.PosStatusSimFound = true;
                response.PosStatusSims = posStatusSims.ConvertToPosStatusSimViews();   
            }
            else
                response.PosStatusSimFound = false;


            return response;
        } 
        
        
        public RemovePosStatusSimResponse RemovePosStatusSim(RemovePosStatusSimRequest request)
        {
            RemovePosStatusSimResponse response = new RemovePosStatusSimResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_posStatusSimRepository.Remove(request.StatusId) > 0)
	            {
        	        response.PosStatusSimDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
