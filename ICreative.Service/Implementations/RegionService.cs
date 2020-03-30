
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
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IUnitOfWork _uow;

        public RegionService(IRegionRepository regionRepository,
                               IUnitOfWork uow)
        {
            _regionRepository = regionRepository;
            _uow = uow;
        }

        public CreateRegionResponse CreateRegion(CreateRegionRequest request)
        {
            CreateRegionResponse response = new CreateRegionResponse();
            Region region = new Region();

                  region.RegionDescription = request.RegionDescription;	
                  region.Territories = request.Territories.ConvertToTerritories();

            if (region.GetBrokenRules().Count() > 0)
            {
                response.Errors = region.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _regionRepository.Add(region);
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


        public GetRegionResponse GetRegion(GetRegionRequest request)
        {
            GetRegionResponse response = new GetRegionResponse();

            Region region = _regionRepository
                                     .FindBy(request.RegionID);

            if (region != null)
            {
                response.RegionFound = true;
                response.Region = region.ConvertToRegionView();
            }
            else
                response.RegionFound = false;


            return response;
        }

        public ModifyRegionResponse ModifyRegion(ModifyRegionRequest request)
        {
            ModifyRegionResponse response = new ModifyRegionResponse();

            Region region = _regionRepository
                                         .FindBy(request.RegionID);

               region.Id = request.RegionID;
                  region.RegionDescription = request.RegionDescription;	
                  region.Territories = request.Territories.ConvertToTerritories();


            if (region.GetBrokenRules().Count() > 0)
            {
                response.Errors = region.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _regionRepository.Save(region);
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
        
        public GetAllRegionResponse GetAllRegions()
        {
            GetAllRegionResponse response = new GetAllRegionResponse();

            IEnumerable<Region> regions = _regionRepository
                                     .FindAll();

            if (regions != null)
            {
                response.RegionFound = true;
                response.Regions = regions.ConvertToRegionViews();   
            }
            else
                response.RegionFound = false;


            return response;
        } 
        
        
        public RemoveRegionResponse RemoveRegion(RemoveRegionRequest request)
        {
            RemoveRegionResponse response = new RemoveRegionResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_regionRepository.Remove(request.RegionID) > 0)
	            {
        	        response.RegionDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
