
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _uow;

        public CategoryService(ICategoryRepository categoryRepository,
                               IUnitOfWork uow)
        {
            _categoryRepository = categoryRepository;
            _uow = uow;
        }

        public CreateCategoryResponse CreateCategory(CreateCategoryRequest request)
        {
            CreateCategoryResponse response = new CreateCategoryResponse();
            Category category = new Category();

                  category.CategoryName = request.CategoryName;	
                  category.Description = request.Description;	
                  category.Picture = request.Picture;	
                  category.Products = request.Products.ConvertToProducts();

            if (category.GetBrokenRules().Count() > 0)
            {
                response.Errors = category.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _categoryRepository.Add(category);
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


        public GetCategoryResponse GetCategory(GetCategoryRequest request)
        {
            GetCategoryResponse response = new GetCategoryResponse();

            Category category = _categoryRepository
                                     .FindBy(request.CategoryID);

            if (category != null)
            {
                response.CategoryFound = true;
                response.Category = category.ConvertToCategoryView();
            }
            else
                response.CategoryFound = false;


            return response;
        }

        public ModifyCategoryResponse ModifyCategory(ModifyCategoryRequest request)
        {
            ModifyCategoryResponse response = new ModifyCategoryResponse();

            Category category = _categoryRepository
                                         .FindBy(request.CategoryID);

               category.Id = request.CategoryID;
                  category.CategoryName = request.CategoryName;	
                  category.Description = request.Description;	
                  category.Picture = request.Picture;	
                  category.Products = request.Products.ConvertToProducts();


            if (category.GetBrokenRules().Count() > 0)
            {
                response.Errors = category.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _categoryRepository.Save(category);
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
        
        public GetAllCategoryResponse GetAllCategories()
        {
            GetAllCategoryResponse response = new GetAllCategoryResponse();

            IEnumerable<Category> categories = _categoryRepository
                                     .FindAll();

            if (categories != null)
            {
                response.CategoryFound = true;
                response.Categories = categories.ConvertToCategoryViews();   
            }
            else
                response.CategoryFound = false;


            return response;
        } 
        
        
        public RemoveCategoryResponse RemoveCategory(RemoveCategoryRequest request)
        {
            RemoveCategoryResponse response = new RemoveCategoryResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_categoryRepository.Remove(request.CategoryID) > 0)
	            {
        	        response.CategoryDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
