
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
    public class TerritoryService : ITerritoryService
    {
        private readonly ITerritoryRepository _territoryRepository;
        private readonly IUnitOfWork _uow;

        public TerritoryService(ITerritoryRepository territoryRepository,
                               IUnitOfWork uow)
        {
            _territoryRepository = territoryRepository;
            _uow = uow;
        }

        public CreateTerritoryResponse CreateTerritory(CreateTerritoryRequest request)
        {
            CreateTerritoryResponse response = new CreateTerritoryResponse();
            Territory territory = new Territory();

                  territory.TerritoryDescription = request.TerritoryDescription;	
                  territory.Employees = request.Employees.ConvertToEmployees();   
                  territory.Region = request.Region.ConvertToRegion();                  

            if (territory.GetBrokenRules().Count() > 0)
            {
                response.Errors = territory.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _territoryRepository.Add(territory);
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


        public GetTerritoryResponse GetTerritory(GetTerritoryRequest request)
        {
            GetTerritoryResponse response = new GetTerritoryResponse();

            Territory territory = _territoryRepository
                                     .FindBy(request.TerritoryID);

            if (territory != null)
            {
                response.TerritoryFound = true;
                response.Territory = territory.ConvertToTerritoryView();
            }
            else
                response.TerritoryFound = false;


            return response;
        }

        public ModifyTerritoryResponse ModifyTerritory(ModifyTerritoryRequest request)
        {
            ModifyTerritoryResponse response = new ModifyTerritoryResponse();

            Territory territory = _territoryRepository
                                         .FindBy(request.TerritoryID);

               territory.Id = request.TerritoryID;
                  territory.TerritoryDescription = request.TerritoryDescription;	
                  territory.Employees = request.Employees.ConvertToEmployees();   
                  territory.Region = request.Region.ConvertToRegion();                  


            if (territory.GetBrokenRules().Count() > 0)
            {
                response.Errors = territory.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _territoryRepository.Save(territory);
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
        
        public GetAllTerritoryResponse GetAllTerritories()
        {
            GetAllTerritoryResponse response = new GetAllTerritoryResponse();

            IEnumerable<Territory> territories = _territoryRepository
                                     .FindAll();

            if (territories != null)
            {
                response.TerritoryFound = true;
                response.Territories = territories.ConvertToTerritoryViews();   
            }
            else
                response.TerritoryFound = false;


            return response;
        } 
        
        
        public RemoveTerritoryResponse RemoveTerritory(RemoveTerritoryRequest request)
        {
            RemoveTerritoryResponse response = new RemoveTerritoryResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_territoryRepository.Remove(request.TerritoryID) > 0)
	            {
        	        response.TerritoryDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
