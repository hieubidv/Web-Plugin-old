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
    public static class TerritoryFlatViewModelMapper
    {
        public static TerritoryFlatViewModel ConvertToTerritoryFlatViewModel(
                                               this TerritoryView territory)
        {
            return Mapper.Map<TerritoryView,
                              TerritoryFlatViewModel>(territory);
        }
        
        
        public static IEnumerable<TerritoryFlatViewModel> ConvertToTerritoryFlatViewModels(
                                                      this IEnumerable<TerritoryView> territories)
        {
            return Mapper.Map<IEnumerable<TerritoryView>, IEnumerable<TerritoryFlatViewModel>>(territories);
        }               

        public static TerritoryDetailView ConvertToTerritoryDetailView(
                                               this TerritoryView territory)
        {
            return Mapper.Map<TerritoryView,
                              TerritoryDetailView>(territory);
        }
        
        
        public static IEnumerable<TerritoryDetailView> ConvertToTerritoryDetailViews(
                                                      this IEnumerable<TerritoryView> territories)
        {
            return Mapper.Map<IEnumerable<TerritoryView>, IEnumerable<TerritoryDetailView>>(territories);
        }

        public static ModifyTerritoryRequest ConvertToModifyTerritoryRequest(
                                               this TerritoryView territories)
        {
            return Mapper.Map<TerritoryView,
                              ModifyTerritoryRequest>(territories);
        }    	

        public static DetailTerritory_TerritoryDetailView ConvertToDetailTerritory_TerritoryDetailView(
                                       this TerritoryView territories)
        {
            return Mapper.Map<TerritoryView,
                              DetailTerritory_TerritoryDetailView>(territories);
        }

        public static IEnumerable<DetailTerritory_EmployeeDetailView> ConvertToDetailTerritoryEmployeeDetailViews(
                                              this IEnumerable<EmployeeView> employees)
        {
            return Mapper.Map<IEnumerable<EmployeeView>, IEnumerable<DetailTerritory_EmployeeDetailView>>(employees);
        }    	

    }

}
