
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class RegionMapper
    {
        public static RegionView ConvertToRegionView(
                                               this Region region)
        {
            return Mapper.Map<Region,
                              RegionView>(region);
        }
        
        
        public static IEnumerable<RegionView> ConvertToRegionViews(
                                                      this IEnumerable<Region> regions)
        {
            return Mapper.Map<IEnumerable<Region>, IEnumerable<RegionView>>(regions);
        }
        
        public static Region ConvertToRegion(
                                               this RegionView regionView)
        {
            return Mapper.Map<RegionView,
                              Region>(regionView);
        }
        
        
        public static IList<Region> ConvertToRegions(
                                                      this IEnumerable<RegionView> regionsView)
        {
            return Mapper.Map<IEnumerable<RegionView>, IList<Region>>(regionsView);
        }        
        
    }

}
