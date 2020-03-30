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
    public static class PosAddressFlatViewModelMapper
    {
        public static PosAddressFlatViewModel ConvertToPosAddressFlatViewModel(
                                               this PosAddressView posAddress)
        {
            return Mapper.Map<PosAddressView,
                              PosAddressFlatViewModel>(posAddress);
        }
        
        
        public static IEnumerable<PosAddressFlatViewModel> ConvertToPosAddressFlatViewModels(
                                                      this IEnumerable<PosAddressView> posAddresses)
        {
            return Mapper.Map<IEnumerable<PosAddressView>, IEnumerable<PosAddressFlatViewModel>>(posAddresses);
        }               

        public static PosAddressDetailView ConvertToPosAddressDetailView(
                                               this PosAddressView posAddress)
        {
            return Mapper.Map<PosAddressView,
                              PosAddressDetailView>(posAddress);
        }
        
        
        public static IEnumerable<PosAddressDetailView> ConvertToPosAddressDetailViews(
                                                      this IEnumerable<PosAddressView> posAddresses)
        {
            return Mapper.Map<IEnumerable<PosAddressView>, IEnumerable<PosAddressDetailView>>(posAddresses);
        }

        public static ModifyPosAddressRequest ConvertToModifyPosAddressRequest(
                                               this PosAddressView posAddresses)
        {
            return Mapper.Map<PosAddressView,
                              ModifyPosAddressRequest>(posAddresses);
        }    	

        public static DetailPosAddress_PosAddressDetailView ConvertToDetailPosAddress_PosAddressDetailView(
                                       this PosAddressView posAddresses)
        {
            return Mapper.Map<PosAddressView,
                              DetailPosAddress_PosAddressDetailView>(posAddresses);
        }

        public static IEnumerable<DetailPosAddress_PosMerchantDetailView> ConvertToDetailPosAddressPosMerchantDetailViews(
                                              this IEnumerable<PosMerchantView> posMerchants)
        {
            return Mapper.Map<IEnumerable<PosMerchantView>, IEnumerable<DetailPosAddress_PosMerchantDetailView>>(posMerchants);
        }    	

    }

}
