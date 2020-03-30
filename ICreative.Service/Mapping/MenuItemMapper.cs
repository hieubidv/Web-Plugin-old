
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class MenuItemMapper
    {
        public static MenuItemView ConvertToMenuItemView(
                                               this MenuItem menuItem)
        {
            return Mapper.Map<MenuItem,
                              MenuItemView>(menuItem);
        }
        
        
        public static IEnumerable<MenuItemView> ConvertToMenuItemViews(
                                                      this IEnumerable<MenuItem> menuItems)
        {
            return Mapper.Map<IEnumerable<MenuItem>, IEnumerable<MenuItemView>>(menuItems);
        }
        
        public static MenuItem ConvertToMenuItem(
                                               this MenuItemView menuItemView)
        {
            return Mapper.Map<MenuItemView,
                              MenuItem>(menuItemView);
        }
        
        
        public static IList<MenuItem> ConvertToMenuItems(
                                                      this IEnumerable<MenuItemView> menuItemsView)
        {
            return Mapper.Map<IEnumerable<MenuItemView>, IList<MenuItem>>(menuItemsView);
        }        
        
    }

}
