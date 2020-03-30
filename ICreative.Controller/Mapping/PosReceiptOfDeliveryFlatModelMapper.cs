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
    public static class PosReceiptOfDeliveryFlatViewModelMapper
    {
        public static PosReceiptOfDeliveryFlatViewModel ConvertToPosReceiptOfDeliveryFlatViewModel(
                                               this PosReceiptOfDeliveryView posReceiptOfDelivery)
        {
            return Mapper.Map<PosReceiptOfDeliveryView,
                              PosReceiptOfDeliveryFlatViewModel>(posReceiptOfDelivery);
        }
        
        
        public static IEnumerable<PosReceiptOfDeliveryFlatViewModel> ConvertToPosReceiptOfDeliveryFlatViewModels(
                                                      this IEnumerable<PosReceiptOfDeliveryView> posReceiptOfDeliveries)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfDeliveryView>, IEnumerable<PosReceiptOfDeliveryFlatViewModel>>(posReceiptOfDeliveries);
        }               

        public static PosReceiptOfDeliveryDetailView ConvertToPosReceiptOfDeliveryDetailView(
                                               this PosReceiptOfDeliveryView posReceiptOfDelivery)
        {
            return Mapper.Map<PosReceiptOfDeliveryView,
                              PosReceiptOfDeliveryDetailView>(posReceiptOfDelivery);
        }
        
        
        public static IEnumerable<PosReceiptOfDeliveryDetailView> ConvertToPosReceiptOfDeliveryDetailViews(
                                                      this IEnumerable<PosReceiptOfDeliveryView> posReceiptOfDeliveries)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfDeliveryView>, IEnumerable<PosReceiptOfDeliveryDetailView>>(posReceiptOfDeliveries);
        }

        public static ModifyPosReceiptOfDeliveryRequest ConvertToModifyPosReceiptOfDeliveryRequest(
                                               this PosReceiptOfDeliveryView posReceiptOfDeliveries)
        {
            return Mapper.Map<PosReceiptOfDeliveryView,
                              ModifyPosReceiptOfDeliveryRequest>(posReceiptOfDeliveries);
        }    	

        public static DetailPosReceiptOfDelivery_PosReceiptOfDeliveryDetailView ConvertToDetailPosReceiptOfDelivery_PosReceiptOfDeliveryDetailView(
                                       this PosReceiptOfDeliveryView posReceiptOfDeliveries)
        {
            return Mapper.Map<PosReceiptOfDeliveryView,
                              DetailPosReceiptOfDelivery_PosReceiptOfDeliveryDetailView>(posReceiptOfDeliveries);
        }

        public static IEnumerable<DetailPosReceiptOfDelivery_PosTerminalDetailView> ConvertToDetailPosReceiptOfDeliveryPosTerminalDetailViews(
                                              this IEnumerable<PosTerminalView> posTerminals)
        {
            return Mapper.Map<IEnumerable<PosTerminalView>, IEnumerable<DetailPosReceiptOfDelivery_PosTerminalDetailView>>(posTerminals);
        }    	

    }

}
