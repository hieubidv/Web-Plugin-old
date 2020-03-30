
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
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IUnitOfWork _uow;

        public MenuItemService(IMenuItemRepository menuItemRepository,
                               IUnitOfWork uow)
        {
            _menuItemRepository = menuItemRepository;
            _uow = uow;
        }

        public CreateMenuItemResponse CreateMenuItem(CreateMenuItemRequest request)
        {
            CreateMenuItemResponse response = new CreateMenuItemResponse();
            MenuItem menuItem = new MenuItem();

                  menuItem.MenuItemName = request.MenuItemName;	
                  menuItem.ParentId = request.ParentId;	
                  menuItem.MenuItemUrl = request.MenuItemUrl;	

            if (menuItem.GetBrokenRules().Count() > 0)
            {
                response.Errors = menuItem.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _menuItemRepository.Add(menuItem);
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


        public GetMenuItemResponse GetMenuItem(GetMenuItemRequest request)
        {
            GetMenuItemResponse response = new GetMenuItemResponse();

            MenuItem menuItem = _menuItemRepository
                                     .FindBy(request.MenuItemId);

            if (menuItem != null)
            {
                response.MenuItemFound = true;
                response.MenuItem = menuItem.ConvertToMenuItemView();
            }
            else
                response.MenuItemFound = false;


            return response;
        }

        public ModifyMenuItemResponse ModifyMenuItem(ModifyMenuItemRequest request)
        {
            ModifyMenuItemResponse response = new ModifyMenuItemResponse();

            MenuItem menuItem = _menuItemRepository
                                         .FindBy(request.MenuItemId);

               menuItem.Id = request.MenuItemId;
                  menuItem.MenuItemName = request.MenuItemName;	
                  menuItem.ParentId = request.ParentId;	
                  menuItem.MenuItemUrl = request.MenuItemUrl;	


            if (menuItem.GetBrokenRules().Count() > 0)
            {
                response.Errors = menuItem.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _menuItemRepository.Save(menuItem);
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
        
        public GetAllMenuItemResponse GetAllMenuItems()
        {
            GetAllMenuItemResponse response = new GetAllMenuItemResponse();

            IEnumerable<MenuItem> menuItems = _menuItemRepository
                                     .FindAll();

            if (menuItems != null)
            {
                response.MenuItemFound = true;
                response.MenuItems = menuItems.ConvertToMenuItemViews();   
            }
            else
                response.MenuItemFound = false;


            return response;
        } 
        
        
        public RemoveMenuItemResponse RemoveMenuItem(RemoveMenuItemRequest request)
        {
            RemoveMenuItemResponse response = new RemoveMenuItemResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_menuItemRepository.Remove(request.MenuItemId) > 0)
	            {
        	        response.MenuItemDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
