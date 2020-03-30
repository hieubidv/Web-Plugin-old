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
    public static class RestrictionFlatViewModelMapper
    {
        public static RestrictionFlatViewModel ConvertToRestrictionFlatViewModel(
                                               this RestrictionView restriction)
        {
            return Mapper.Map<RestrictionView,
                              RestrictionFlatViewModel>(restriction);
        }
        
        
        public static IEnumerable<RestrictionFlatViewModel> ConvertToRestrictionFlatViewModels(
                                                      this IEnumerable<RestrictionView> restrictions)
        {
            return Mapper.Map<IEnumerable<RestrictionView>, IEnumerable<RestrictionFlatViewModel>>(restrictions);
        }               

        public static RestrictionDetailView ConvertToRestrictionDetailView(
                                               this RestrictionView restriction)
        {
            return Mapper.Map<RestrictionView,
                              RestrictionDetailView>(restriction);
        }
        
        
        public static IEnumerable<RestrictionDetailView> ConvertToRestrictionDetailViews(
                                                      this IEnumerable<RestrictionView> restrictions)
        {
            return Mapper.Map<IEnumerable<RestrictionView>, IEnumerable<RestrictionDetailView>>(restrictions);
        }

        public static ModifyRestrictionRequest ConvertToModifyRestrictionRequest(
                                               this RestrictionView restrictions)
        {
            return Mapper.Map<RestrictionView,
                              ModifyRestrictionRequest>(restrictions);
        }    	

        public static DetailRestriction_RestrictionDetailView ConvertToDetailRestriction_RestrictionDetailView(
                                       this RestrictionView restrictions)
        {
            return Mapper.Map<RestrictionView,
                              DetailRestriction_RestrictionDetailView>(restrictions);
        }


    }

}
