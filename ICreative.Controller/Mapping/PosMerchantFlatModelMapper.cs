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
    public static class PosMerchantFlatViewModelMapper
    {
        public static PosMerchantFlatViewModel ConvertToPosMerchantFlatViewModel(
                                               this PosMerchantView posMerchant)
        {
            return Mapper.Map<PosMerchantView,
                              PosMerchantFlatViewModel>(posMerchant);
        }
        
        
        public static IEnumerable<PosMerchantFlatViewModel> ConvertToPosMerchantFlatViewModels(
                                                      this IEnumerable<PosMerchantView> posMerchants)
        {
            return Mapper.Map<IEnumerable<PosMerchantView>, IEnumerable<PosMerchantFlatViewModel>>(posMerchants);
        }               

        public static PosMerchantDetailView ConvertToPosMerchantDetailView(
                                               this PosMerchantView posMerchant)
        {
            return Mapper.Map<PosMerchantView,
                              PosMerchantDetailView>(posMerchant);
        }
        
        
        public static IEnumerable<PosMerchantDetailView> ConvertToPosMerchantDetailViews(
                                                      this IEnumerable<PosMerchantView> posMerchants)
        {
            return Mapper.Map<IEnumerable<PosMerchantView>, IEnumerable<PosMerchantDetailView>>(posMerchants);
        }

        public static ModifyPosMerchantRequest ConvertToModifyPosMerchantRequest(
                                               this PosMerchantView posMerchants)
        {
            return Mapper.Map<PosMerchantView,
                              ModifyPosMerchantRequest>(posMerchants);
        }    	

        public static DetailPosMerchant_PosMerchantDetailView ConvertToDetailPosMerchant_PosMerchantDetailView(
                                       this PosMerchantView posMerchants)
        {
            return Mapper.Map<PosMerchantView,
                              DetailPosMerchant_PosMerchantDetailView>(posMerchants);
        }

        public static IEnumerable<DetailPosMerchant_PosReceiptOfTestingDetailView> ConvertToDetailPosMerchantPosReceiptOfTestingDetailViews(
                                              this IEnumerable<PosReceiptOfTestingView> posReceiptOfTestings)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfTestingView>, IEnumerable<DetailPosMerchant_PosReceiptOfTestingDetailView>>(posReceiptOfTestings);
        }    	

    }

}
