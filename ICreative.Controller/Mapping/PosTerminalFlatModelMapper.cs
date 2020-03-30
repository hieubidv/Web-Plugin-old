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
    public static class PosTerminalFlatViewModelMapper
    {
        public static PosTerminalFlatViewModel ConvertToPosTerminalFlatViewModel(
                                               this PosTerminalView posTerminal)
        {
            return Mapper.Map<PosTerminalView,
                              PosTerminalFlatViewModel>(posTerminal);
        }
        
        
        public static IEnumerable<PosTerminalFlatViewModel> ConvertToPosTerminalFlatViewModels(
                                                      this IEnumerable<PosTerminalView> posTerminals)
        {
            return Mapper.Map<IEnumerable<PosTerminalView>, IEnumerable<PosTerminalFlatViewModel>>(posTerminals);
        }               

        public static PosTerminalDetailView ConvertToPosTerminalDetailView(
                                               this PosTerminalView posTerminal)
        {
            return Mapper.Map<PosTerminalView,
                              PosTerminalDetailView>(posTerminal);
        }
        
        
        public static IEnumerable<PosTerminalDetailView> ConvertToPosTerminalDetailViews(
                                                      this IEnumerable<PosTerminalView> posTerminals)
        {
            return Mapper.Map<IEnumerable<PosTerminalView>, IEnumerable<PosTerminalDetailView>>(posTerminals);
        }

        public static ModifyPosTerminalRequest ConvertToModifyPosTerminalRequest(
                                               this PosTerminalView posTerminals)
        {
            return Mapper.Map<PosTerminalView,
                              ModifyPosTerminalRequest>(posTerminals);
        }    	

        public static DetailPosTerminal_PosTerminalDetailView ConvertToDetailPosTerminal_PosTerminalDetailView(
                                       this PosTerminalView posTerminals)
        {
            return Mapper.Map<PosTerminalView,
                              DetailPosTerminal_PosTerminalDetailView>(posTerminals);
        }

        public static IEnumerable<DetailPosTerminal_PosReceiptOfDeliveryDetailView> ConvertToDetailPosTerminalPosReceiptOfDeliveryDetailViews(
                                              this IEnumerable<PosReceiptOfDeliveryView> posReceiptOfDeliveries)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfDeliveryView>, IEnumerable<DetailPosTerminal_PosReceiptOfDeliveryDetailView>>(posReceiptOfDeliveries);
        }    	
        public static IEnumerable<DetailPosTerminal_PosReceiptOfTestingDetailView> ConvertToDetailPosTerminalPosReceiptOfTestingDetailViews(
                                              this IEnumerable<PosReceiptOfTestingView> posReceiptOfTestings)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfTestingView>, IEnumerable<DetailPosTerminal_PosReceiptOfTestingDetailView>>(posReceiptOfTestings);
        }    	

    }

}
