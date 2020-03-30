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
    public static class RegionFlatViewModelMapper
    {
        public static RegionFlatViewModel ConvertToRegionFlatViewModel(
                                               this RegionView region)
        {
            return Mapper.Map<RegionView,
                              RegionFlatViewModel>(region);
        }
        
        
        public static IEnumerable<RegionFlatViewModel> ConvertToRegionFlatViewModels(
                                                      this IEnumerable<RegionView> regions)
        {
            return Mapper.Map<IEnumerable<RegionView>, IEnumerable<RegionFlatViewModel>>(regions);
        }               

        public static RegionDetailView ConvertToRegionDetailView(
                                               this RegionView region)
        {
            return Mapper.Map<RegionView,
                              RegionDetailView>(region);
        }
        
        
        public static IEnumerable<RegionDetailView> ConvertToRegionDetailViews(
                                                      this IEnumerable<RegionView> regions)
        {
            return Mapper.Map<IEnumerable<RegionView>, IEnumerable<RegionDetailView>>(regions);
        }

        public static ModifyRegionRequest ConvertToModifyRegionRequest(
                                               this RegionView regions)
        {
            return Mapper.Map<RegionView,
                              ModifyRegionRequest>(regions);
        }    	

        public static DetailRegion_RegionDetailView ConvertToDetailRegion_RegionDetailView(
                                       this RegionView regions)
        {
            return Mapper.Map<RegionView,
                              DetailRegion_RegionDetailView>(regions);
        }

        public static IEnumerable<DetailRegion_TerritoryDetailView> ConvertToDetailRegionTerritoryDetailViews(
                                              this IEnumerable<TerritoryView> territories)
        {
            return Mapper.Map<IEnumerable<TerritoryView>, IEnumerable<DetailRegion_TerritoryDetailView>>(territories);
        }    	

    }

}
