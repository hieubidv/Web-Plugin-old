using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using ICreative.Controllers.ViewModels;
using ICreative.Services.Messaging;
using AutoMapper;
namespace ICreative.Controllers.Mapping
{
    public static class MenuItemFlatViewModelMapper
    {
        public static MenuItemFlatViewModel ConvertToMenuItemFlatViewModel(
                                               this MenuItemView menuItem)
        {
            return Mapper.Map<MenuItemView,
                              MenuItemFlatViewModel>(menuItem);
        }
        
        
        public static IEnumerable<MenuItemFlatViewModel> ConvertToMenuItemFlatViewModels(
                                                      this IEnumerable<MenuItemView> menuItems)
        {
            return Mapper.Map<IEnumerable<MenuItemView>, IEnumerable<MenuItemFlatViewModel>>(menuItems);
        }               

        public static MenuItemDetailView ConvertToMenuItemDetailView(
                                               this MenuItemView menuItem)
        {
            return Mapper.Map<MenuItemView,
                              MenuItemDetailView>(menuItem);
        }
        
        
        public static IEnumerable<MenuItemDetailView> ConvertToMenuItemDetailViews(
                                                      this IEnumerable<MenuItemView> menuItems)
        {
            return Mapper.Map<IEnumerable<MenuItemView>, IEnumerable<MenuItemDetailView>>(menuItems);
        }

        public static ModifyMenuItemRequest ConvertToModifyMenuItemRequest(
                                               this MenuItemView menuItems)
        {
            return Mapper.Map<MenuItemView,
                              ModifyMenuItemRequest>(menuItems);
        }    	

        public static DetailMenuItem_MenuItemDetailView ConvertToDetailMenuItem_MenuItemDetailView(
                                       this MenuItemView menuItems)
        {
            return Mapper.Map<MenuItemView,
                              DetailMenuItem_MenuItemDetailView>(menuItems);
        }


    }

}
