
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
    public class PosSimProviderService : IPosSimProviderService
    {
        private readonly IPosSimProviderRepository _posSimProviderRepository;
        private readonly IUnitOfWork _uow;

        public PosSimProviderService(IPosSimProviderRepository posSimProviderRepository,
                               IUnitOfWork uow)
        {
            _posSimProviderRepository = posSimProviderRepository;
            _uow = uow;
        }

        public CreatePosSimProviderResponse CreatePosSimProvider(CreatePosSimProviderRequest request)
        {
            CreatePosSimProviderResponse response = new CreatePosSimProviderResponse();
            PosSimProvider posSimProvider = new PosSimProvider();

                  posSimProvider.SimProviderName = request.SimProviderName;	
                  posSimProvider.PosSims = request.PosSims.ConvertToPosSims();

            if (posSimProvider.GetBrokenRules().Count() > 0)
            {
                response.Errors = posSimProvider.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _posSimProviderRepository.Add(posSimProvider);
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


        public GetPosSimProviderResponse GetPosSimProvider(GetPosSimProviderRequest request)
        {
            GetPosSimProviderResponse response = new GetPosSimProviderResponse();

            PosSimProvider posSimProvider = _posSimProviderRepository
                                     .FindBy(request.SimProviderId);

            if (posSimProvider != null)
            {
                response.PosSimProviderFound = true;
                response.PosSimProvider = posSimProvider.ConvertToPosSimProviderView();
            }
            else
                response.PosSimProviderFound = false;


            return response;
        }

        public ModifyPosSimProviderResponse ModifyPosSimProvider(ModifyPosSimProviderRequest request)
        {
            ModifyPosSimProviderResponse response = new ModifyPosSimProviderResponse();

            PosSimProvider posSimProvider = _posSimProviderRepository
                                         .FindBy(request.SimProviderId);

               posSimProvider.Id = request.SimProviderId;
                  posSimProvider.SimProviderName = request.SimProviderName;	
                  posSimProvider.PosSims = request.PosSims.ConvertToPosSims();


            if (posSimProvider.GetBrokenRules().Count() > 0)
            {
                response.Errors = posSimProvider.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _posSimProviderRepository.Save(posSimProvider);
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
        
        public GetAllPosSimProviderResponse GetAllPosSimProviders()
        {
            GetAllPosSimProviderResponse response = new GetAllPosSimProviderResponse();

            IEnumerable<PosSimProvider> posSimProviders = _posSimProviderRepository
                                     .FindAll();

            if (posSimProviders != null)
            {
                response.PosSimProviderFound = true;
                response.PosSimProviders = posSimProviders.ConvertToPosSimProviderViews();   
            }
            else
                response.PosSimProviderFound = false;


            return response;
        } 
        
        
        public RemovePosSimProviderResponse RemovePosSimProvider(RemovePosSimProviderRequest request)
        {
            RemovePosSimProviderResponse response = new RemovePosSimProviderResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_posSimProviderRepository.Remove(request.SimProviderId) > 0)
	            {
        	        response.PosSimProviderDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
