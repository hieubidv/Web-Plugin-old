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
    public static class PosStatusTerminalFlatViewModelMapper
    {
        public static PosStatusTerminalFlatViewModel ConvertToPosStatusTerminalFlatViewModel(
                                               this PosStatusTerminalView posStatusTerminal)
        {
            return Mapper.Map<PosStatusTerminalView,
                              PosStatusTerminalFlatViewModel>(posStatusTerminal);
        }
        
        
        public static IEnumerable<PosStatusTerminalFlatViewModel> ConvertToPosStatusTerminalFlatViewModels(
                                                      this IEnumerable<PosStatusTerminalView> posStatusTerminals)
        {
            return Mapper.Map<IEnumerable<PosStatusTerminalView>, IEnumerable<PosStatusTerminalFlatViewModel>>(posStatusTerminals);
        }               

        public static PosStatusTerminalDetailView ConvertToPosStatusTerminalDetailView(
                                               this PosStatusTerminalView posStatusTerminal)
        {
            return Mapper.Map<PosStatusTerminalView,
                              PosStatusTerminalDetailView>(posStatusTerminal);
        }
        
        
        public static IEnumerable<PosStatusTerminalDetailView> ConvertToPosStatusTerminalDetailViews(
                                                      this IEnumerable<PosStatusTerminalView> posStatusTerminals)
        {
            return Mapper.Map<IEnumerable<PosStatusTerminalView>, IEnumerable<PosStatusTerminalDetailView>>(posStatusTerminals);
        }

        public static ModifyPosStatusTerminalRequest ConvertToModifyPosStatusTerminalRequest(
                                               this PosStatusTerminalView posStatusTerminals)
        {
            return Mapper.Map<PosStatusTerminalView,
                              ModifyPosStatusTerminalRequest>(posStatusTerminals);
        }    	

        public static DetailPosStatusTerminal_PosStatusTerminalDetailView ConvertToDetailPosStatusTerminal_PosStatusTerminalDetailView(
                                       this PosStatusTerminalView posStatusTerminals)
        {
            return Mapper.Map<PosStatusTerminalView,
                              DetailPosStatusTerminal_PosStatusTerminalDetailView>(posStatusTerminals);
        }

        public static IEnumerable<DetailPosStatusTerminal_PosTerminalDetailView> ConvertToDetailPosStatusTerminalPosTerminalDetailViews(
                                              this IEnumerable<PosTerminalView> posTerminals)
        {
            return Mapper.Map<IEnumerable<PosTerminalView>, IEnumerable<DetailPosStatusTerminal_PosTerminalDetailView>>(posTerminals);
        }    	

    }

}
