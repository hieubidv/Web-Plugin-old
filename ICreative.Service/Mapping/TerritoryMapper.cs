
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class TerritoryMapper
    {
        public static TerritoryView ConvertToTerritoryView(
                                               this Territory territory)
        {
            return Mapper.Map<Territory,
                              TerritoryView>(territory);
        }
        
        
        public static IEnumerable<TerritoryView> ConvertToTerritoryViews(
                                                      this IEnumerable<Territory> territories)
        {
            return Mapper.Map<IEnumerable<Territory>, IEnumerable<TerritoryView>>(territories);
        }
        
        public static Territory ConvertToTerritory(
                                               this TerritoryView territoryView)
        {
            return Mapper.Map<TerritoryView,
                              Territory>(territoryView);
        }
        
        
        public static IList<Territory> ConvertToTerritories(
                                                      this IEnumerable<TerritoryView> territoriesView)
        {
            return Mapper.Map<IEnumerable<TerritoryView>, IList<Territory>>(territoriesView);
        }        
        
    }

}
