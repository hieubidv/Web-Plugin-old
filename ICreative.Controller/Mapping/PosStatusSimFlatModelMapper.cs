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
    public static class PosStatusSimFlatViewModelMapper
    {
        public static PosStatusSimFlatViewModel ConvertToPosStatusSimFlatViewModel(
                                               this PosStatusSimView posStatusSim)
        {
            return Mapper.Map<PosStatusSimView,
                              PosStatusSimFlatViewModel>(posStatusSim);
        }
        
        
        public static IEnumerable<PosStatusSimFlatViewModel> ConvertToPosStatusSimFlatViewModels(
                                                      this IEnumerable<PosStatusSimView> posStatusSims)
        {
            return Mapper.Map<IEnumerable<PosStatusSimView>, IEnumerable<PosStatusSimFlatViewModel>>(posStatusSims);
        }               

        public static PosStatusSimDetailView ConvertToPosStatusSimDetailView(
                                               this PosStatusSimView posStatusSim)
        {
            return Mapper.Map<PosStatusSimView,
                              PosStatusSimDetailView>(posStatusSim);
        }
        
        
        public static IEnumerable<PosStatusSimDetailView> ConvertToPosStatusSimDetailViews(
                                                      this IEnumerable<PosStatusSimView> posStatusSims)
        {
            return Mapper.Map<IEnumerable<PosStatusSimView>, IEnumerable<PosStatusSimDetailView>>(posStatusSims);
        }

        public static ModifyPosStatusSimRequest ConvertToModifyPosStatusSimRequest(
                                               this PosStatusSimView posStatusSims)
        {
            return Mapper.Map<PosStatusSimView,
                              ModifyPosStatusSimRequest>(posStatusSims);
        }    	

        public static DetailPosStatusSim_PosStatusSimDetailView ConvertToDetailPosStatusSim_PosStatusSimDetailView(
                                       this PosStatusSimView posStatusSims)
        {
            return Mapper.Map<PosStatusSimView,
                              DetailPosStatusSim_PosStatusSimDetailView>(posStatusSims);
        }

        public static IEnumerable<DetailPosStatusSim_PosSimDetailView> ConvertToDetailPosStatusSimPosSimDetailViews(
                                              this IEnumerable<PosSimView> posSims)
        {
            return Mapper.Map<IEnumerable<PosSimView>, IEnumerable<DetailPosStatusSim_PosSimDetailView>>(posSims);
        }    	

    }

}
