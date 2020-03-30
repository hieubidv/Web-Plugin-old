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
    public static class PosSimFlatViewModelMapper
    {
        public static PosSimFlatViewModel ConvertToPosSimFlatViewModel(
                                               this PosSimView posSim)
        {
            return Mapper.Map<PosSimView,
                              PosSimFlatViewModel>(posSim);
        }
        
        
        public static IEnumerable<PosSimFlatViewModel> ConvertToPosSimFlatViewModels(
                                                      this IEnumerable<PosSimView> posSims)
        {
            return Mapper.Map<IEnumerable<PosSimView>, IEnumerable<PosSimFlatViewModel>>(posSims);
        }               

        public static PosSimDetailView ConvertToPosSimDetailView(
                                               this PosSimView posSim)
        {
            return Mapper.Map<PosSimView,
                              PosSimDetailView>(posSim);
        }
        
        
        public static IEnumerable<PosSimDetailView> ConvertToPosSimDetailViews(
                                                      this IEnumerable<PosSimView> posSims)
        {
            return Mapper.Map<IEnumerable<PosSimView>, IEnumerable<PosSimDetailView>>(posSims);
        }

        public static ModifyPosSimRequest ConvertToModifyPosSimRequest(
                                               this PosSimView posSims)
        {
            return Mapper.Map<PosSimView,
                              ModifyPosSimRequest>(posSims);
        }    	

        public static DetailPosSim_PosSimDetailView ConvertToDetailPosSim_PosSimDetailView(
                                       this PosSimView posSims)
        {
            return Mapper.Map<PosSimView,
                              DetailPosSim_PosSimDetailView>(posSims);
        }

        public static IEnumerable<DetailPosSim_PosTerminalDetailView> ConvertToDetailPosSimPosTerminalDetailViews(
                                              this IEnumerable<PosTerminalView> posTerminals)
        {
            return Mapper.Map<IEnumerable<PosTerminalView>, IEnumerable<DetailPosSim_PosTerminalDetailView>>(posTerminals);
        }    	

    }

}
