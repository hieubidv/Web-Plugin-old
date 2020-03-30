
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
    public class RestrictionService : IRestrictionService
    {
        private readonly IRestrictionRepository _restrictionRepository;
        private readonly IUnitOfWork _uow;

        public RestrictionService(IRestrictionRepository restrictionRepository,
                               IUnitOfWork uow)
        {
            _restrictionRepository = restrictionRepository;
            _uow = uow;
        }

        public CreateRestrictionResponse CreateRestriction(CreateRestrictionRequest request)
        {
            CreateRestrictionResponse response = new CreateRestrictionResponse();
            Restriction restriction = new Restriction();

                  restriction.RestrictionName = request.RestrictionName;	
                  restriction.RequirePermission = request.RequirePermission;	
                  restriction.RestrictionDescription = request.RestrictionDescription;	

            if (restriction.GetBrokenRules().Count() > 0)
            {
                response.Errors = restriction.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _restrictionRepository.Add(restriction);
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


        public GetRestrictionResponse GetRestriction(GetRestrictionRequest request)
        {
            GetRestrictionResponse response = new GetRestrictionResponse();

            Restriction restriction = _restrictionRepository
                                     .FindBy(request.RestrictionId);

            if (restriction != null)
            {
                response.RestrictionFound = true;
                response.Restriction = restriction.ConvertToRestrictionView();
            }
            else
                response.RestrictionFound = false;


            return response;
        }

        public ModifyRestrictionResponse ModifyRestriction(ModifyRestrictionRequest request)
        {
            ModifyRestrictionResponse response = new ModifyRestrictionResponse();

            Restriction restriction = _restrictionRepository
                                         .FindBy(request.RestrictionId);

               restriction.Id = request.RestrictionId;
                  restriction.RestrictionName = request.RestrictionName;	
                  restriction.RequirePermission = request.RequirePermission;	
                  restriction.RestrictionDescription = request.RestrictionDescription;	


            if (restriction.GetBrokenRules().Count() > 0)
            {
                response.Errors = restriction.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _restrictionRepository.Save(restriction);
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
        
        public GetAllRestrictionResponse GetAllRestrictions()
        {
            GetAllRestrictionResponse response = new GetAllRestrictionResponse();

            IEnumerable<Restriction> restrictions = _restrictionRepository
                                     .FindAll();

            if (restrictions != null)
            {
                response.RestrictionFound = true;
                response.Restrictions = restrictions.ConvertToRestrictionViews();   
            }
            else
                response.RestrictionFound = false;


            return response;
        } 
        
        
        public RemoveRestrictionResponse RemoveRestriction(RemoveRestrictionRequest request)
        {
            RemoveRestrictionResponse response = new RemoveRestrictionResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_restrictionRepository.Remove(request.RestrictionId) > 0)
	            {
        	        response.RestrictionDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
