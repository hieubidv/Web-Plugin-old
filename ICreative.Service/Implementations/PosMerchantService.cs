
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
    public class PosMerchantService : IPosMerchantService
    {
        private readonly IPosMerchantRepository _posMerchantRepository;
        private readonly IUnitOfWork _uow;

        public PosMerchantService(IPosMerchantRepository posMerchantRepository,
                               IUnitOfWork uow)
        {
            _posMerchantRepository = posMerchantRepository;
            _uow = uow;
        }

        public CreatePosMerchantResponse CreatePosMerchant(CreatePosMerchantRequest request)
        {
            CreatePosMerchantResponse response = new CreatePosMerchantResponse();
            PosMerchant posMerchant = new PosMerchant();

                  posMerchant.MerchantName = request.MerchantName;	
                  posMerchant.BusinessName = request.BusinessName;	
                  posMerchant.BannerName = request.BannerName;	
                  posMerchant.MerchantIdByHeadQuater = request.MerchantIdByHeadQuater;	
                  posMerchant.PosReceiptOfTestings = request.PosReceiptOfTestings.ConvertToPosReceiptOfTestings();
                  posMerchant.PosAddress = request.PosAddress.ConvertToPosAddress();                  

            if (posMerchant.GetBrokenRules().Count() > 0)
            {
                response.Errors = posMerchant.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _posMerchantRepository.Add(posMerchant);
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


        public GetPosMerchantResponse GetPosMerchant(GetPosMerchantRequest request)
        {
            GetPosMerchantResponse response = new GetPosMerchantResponse();

            PosMerchant posMerchant = _posMerchantRepository
                                     .FindBy(request.MerchantId);

            if (posMerchant != null)
            {
                response.PosMerchantFound = true;
                response.PosMerchant = posMerchant.ConvertToPosMerchantView();
            }
            else
                response.PosMerchantFound = false;


            return response;
        }

        public ModifyPosMerchantResponse ModifyPosMerchant(ModifyPosMerchantRequest request)
        {
            ModifyPosMerchantResponse response = new ModifyPosMerchantResponse();

            PosMerchant posMerchant = _posMerchantRepository
                                         .FindBy(request.MerchantId);

               posMerchant.Id = request.MerchantId;
                  posMerchant.MerchantName = request.MerchantName;	
                  posMerchant.BusinessName = request.BusinessName;	
                  posMerchant.BannerName = request.BannerName;	
                  posMerchant.MerchantIdByHeadQuater = request.MerchantIdByHeadQuater;	
                  posMerchant.PosReceiptOfTestings = request.PosReceiptOfTestings.ConvertToPosReceiptOfTestings();
                  posMerchant.PosAddress = request.PosAddress.ConvertToPosAddress();                  


            if (posMerchant.GetBrokenRules().Count() > 0)
            {
                response.Errors = posMerchant.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _posMerchantRepository.Save(posMerchant);
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
        
        public GetAllPosMerchantResponse GetAllPosMerchants()
        {
            GetAllPosMerchantResponse response = new GetAllPosMerchantResponse();

            IEnumerable<PosMerchant> posMerchants = _posMerchantRepository
                                     .FindAll();

            if (posMerchants != null)
            {
                response.PosMerchantFound = true;
                response.PosMerchants = posMerchants.ConvertToPosMerchantViews();   
            }
            else
                response.PosMerchantFound = false;


            return response;
        } 
        
        
        public RemovePosMerchantResponse RemovePosMerchant(RemovePosMerchantRequest request)
        {
            RemovePosMerchantResponse response = new RemovePosMerchantResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_posMerchantRepository.Remove(request.MerchantId) > 0)
	            {
        	        response.PosMerchantDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
