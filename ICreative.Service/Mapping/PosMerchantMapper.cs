
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PosMerchantMapper
    {
        public static PosMerchantView ConvertToPosMerchantView(
                                               this PosMerchant posMerchant)
        {
            return Mapper.Map<PosMerchant,
                              PosMerchantView>(posMerchant);
        }
        
        
        public static IEnumerable<PosMerchantView> ConvertToPosMerchantViews(
                                                      this IEnumerable<PosMerchant> posMerchants)
        {
            return Mapper.Map<IEnumerable<PosMerchant>, IEnumerable<PosMerchantView>>(posMerchants);
        }
        
        public static PosMerchant ConvertToPosMerchant(
                                               this PosMerchantView posMerchantView)
        {
            return Mapper.Map<PosMerchantView,
                              PosMerchant>(posMerchantView);
        }
        
        
        public static IList<PosMerchant> ConvertToPosMerchants(
                                                      this IEnumerable<PosMerchantView> posMerchantsView)
        {
            return Mapper.Map<IEnumerable<PosMerchantView>, IList<PosMerchant>>(posMerchantsView);
        }        
        
    }

}
