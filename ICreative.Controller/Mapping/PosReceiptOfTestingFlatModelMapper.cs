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
    public static class PosReceiptOfTestingFlatViewModelMapper
    {
        public static PosReceiptOfTestingFlatViewModel ConvertToPosReceiptOfTestingFlatViewModel(
                                               this PosReceiptOfTestingView posReceiptOfTesting)
        {
            return Mapper.Map<PosReceiptOfTestingView,
                              PosReceiptOfTestingFlatViewModel>(posReceiptOfTesting);
        }
        
        
        public static IEnumerable<PosReceiptOfTestingFlatViewModel> ConvertToPosReceiptOfTestingFlatViewModels(
                                                      this IEnumerable<PosReceiptOfTestingView> posReceiptOfTestings)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfTestingView>, IEnumerable<PosReceiptOfTestingFlatViewModel>>(posReceiptOfTestings);
        }               

        public static PosReceiptOfTestingDetailView ConvertToPosReceiptOfTestingDetailView(
                                               this PosReceiptOfTestingView posReceiptOfTesting)
        {
            return Mapper.Map<PosReceiptOfTestingView,
                              PosReceiptOfTestingDetailView>(posReceiptOfTesting);
        }
        
        
        public static IEnumerable<PosReceiptOfTestingDetailView> ConvertToPosReceiptOfTestingDetailViews(
                                                      this IEnumerable<PosReceiptOfTestingView> posReceiptOfTestings)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfTestingView>, IEnumerable<PosReceiptOfTestingDetailView>>(posReceiptOfTestings);
        }

        public static ModifyPosReceiptOfTestingRequest ConvertToModifyPosReceiptOfTestingRequest(
                                               this PosReceiptOfTestingView posReceiptOfTestings)
        {
            return Mapper.Map<PosReceiptOfTestingView,
                              ModifyPosReceiptOfTestingRequest>(posReceiptOfTestings);
        }    	

        public static DetailPosReceiptOfTesting_PosReceiptOfTestingDetailView ConvertToDetailPosReceiptOfTesting_PosReceiptOfTestingDetailView(
                                       this PosReceiptOfTestingView posReceiptOfTestings)
        {
            return Mapper.Map<PosReceiptOfTestingView,
                              DetailPosReceiptOfTesting_PosReceiptOfTestingDetailView>(posReceiptOfTestings);
        }

        public static IEnumerable<DetailPosReceiptOfTesting_PosTerminalDetailView> ConvertToDetailPosReceiptOfTestingPosTerminalDetailViews(
                                              this IEnumerable<PosTerminalView> posTerminals)
        {
            return Mapper.Map<IEnumerable<PosTerminalView>, IEnumerable<DetailPosReceiptOfTesting_PosTerminalDetailView>>(posTerminals);
        }    	

    }

}
