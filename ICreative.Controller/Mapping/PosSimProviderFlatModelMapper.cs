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
    public static class PosSimProviderFlatViewModelMapper
    {
        public static PosSimProviderFlatViewModel ConvertToPosSimProviderFlatViewModel(
                                               this PosSimProviderView posSimProvider)
        {
            return Mapper.Map<PosSimProviderView,
                              PosSimProviderFlatViewModel>(posSimProvider);
        }
        
        
        public static IEnumerable<PosSimProviderFlatViewModel> ConvertToPosSimProviderFlatViewModels(
                                                      this IEnumerable<PosSimProviderView> posSimProviders)
        {
            return Mapper.Map<IEnumerable<PosSimProviderView>, IEnumerable<PosSimProviderFlatViewModel>>(posSimProviders);
        }               

        public static PosSimProviderDetailView ConvertToPosSimProviderDetailView(
                                               this PosSimProviderView posSimProvider)
        {
            return Mapper.Map<PosSimProviderView,
                              PosSimProviderDetailView>(posSimProvider);
        }
        
        
        public static IEnumerable<PosSimProviderDetailView> ConvertToPosSimProviderDetailViews(
                                                      this IEnumerable<PosSimProviderView> posSimProviders)
        {
            return Mapper.Map<IEnumerable<PosSimProviderView>, IEnumerable<PosSimProviderDetailView>>(posSimProviders);
        }

        public static ModifyPosSimProviderRequest ConvertToModifyPosSimProviderRequest(
                                               this PosSimProviderView posSimProviders)
        {
            return Mapper.Map<PosSimProviderView,
                              ModifyPosSimProviderRequest>(posSimProviders);
        }    	

        public static DetailPosSimProvider_PosSimProviderDetailView ConvertToDetailPosSimProvider_PosSimProviderDetailView(
                                       this PosSimProviderView posSimProviders)
        {
            return Mapper.Map<PosSimProviderView,
                              DetailPosSimProvider_PosSimProviderDetailView>(posSimProviders);
        }

        public static IEnumerable<DetailPosSimProvider_PosSimDetailView> ConvertToDetailPosSimProviderPosSimDetailViews(
                                              this IEnumerable<PosSimView> posSims)
        {
            return Mapper.Map<IEnumerable<PosSimView>, IEnumerable<DetailPosSimProvider_PosSimDetailView>>(posSims);
        }    	

    }

}
