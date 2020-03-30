
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PosSimProviderMapper
    {
        public static PosSimProviderView ConvertToPosSimProviderView(
                                               this PosSimProvider posSimProvider)
        {
            return Mapper.Map<PosSimProvider,
                              PosSimProviderView>(posSimProvider);
        }
        
        
        public static IEnumerable<PosSimProviderView> ConvertToPosSimProviderViews(
                                                      this IEnumerable<PosSimProvider> posSimProviders)
        {
            return Mapper.Map<IEnumerable<PosSimProvider>, IEnumerable<PosSimProviderView>>(posSimProviders);
        }
        
        public static PosSimProvider ConvertToPosSimProvider(
                                               this PosSimProviderView posSimProviderView)
        {
            return Mapper.Map<PosSimProviderView,
                              PosSimProvider>(posSimProviderView);
        }
        
        
        public static IList<PosSimProvider> ConvertToPosSimProviders(
                                                      this IEnumerable<PosSimProviderView> posSimProvidersView)
        {
            return Mapper.Map<IEnumerable<PosSimProviderView>, IList<PosSimProvider>>(posSimProvidersView);
        }        
        
    }

}
