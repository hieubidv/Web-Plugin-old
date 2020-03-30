
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class RestrictionMapper
    {
        public static RestrictionView ConvertToRestrictionView(
                                               this Restriction restriction)
        {
            return Mapper.Map<Restriction,
                              RestrictionView>(restriction);
        }
        
        
        public static IEnumerable<RestrictionView> ConvertToRestrictionViews(
                                                      this IEnumerable<Restriction> restrictions)
        {
            return Mapper.Map<IEnumerable<Restriction>, IEnumerable<RestrictionView>>(restrictions);
        }
        
        public static Restriction ConvertToRestriction(
                                               this RestrictionView restrictionView)
        {
            return Mapper.Map<RestrictionView,
                              Restriction>(restrictionView);
        }
        
        
        public static IList<Restriction> ConvertToRestrictions(
                                                      this IEnumerable<RestrictionView> restrictionsView)
        {
            return Mapper.Map<IEnumerable<RestrictionView>, IList<Restriction>>(restrictionsView);
        }        
        
    }

}
