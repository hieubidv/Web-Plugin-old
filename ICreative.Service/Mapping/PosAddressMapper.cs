
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PosAddressMapper
    {
        public static PosAddressView ConvertToPosAddressView(
                                               this PosAddress posAddress)
        {
            return Mapper.Map<PosAddress,
                              PosAddressView>(posAddress);
        }
        
        
        public static IEnumerable<PosAddressView> ConvertToPosAddressViews(
                                                      this IEnumerable<PosAddress> posAddresses)
        {
            return Mapper.Map<IEnumerable<PosAddress>, IEnumerable<PosAddressView>>(posAddresses);
        }
        
        public static PosAddress ConvertToPosAddress(
                                               this PosAddressView posAddressView)
        {
            return Mapper.Map<PosAddressView,
                              PosAddress>(posAddressView);
        }
        
        
        public static IList<PosAddress> ConvertToPosAddresses(
                                                      this IEnumerable<PosAddressView> posAddressesView)
        {
            return Mapper.Map<IEnumerable<PosAddressView>, IList<PosAddress>>(posAddressesView);
        }        
        
    }

}
