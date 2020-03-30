
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PosStatusSimMapper
    {
        public static PosStatusSimView ConvertToPosStatusSimView(
                                               this PosStatusSim posStatusSim)
        {
            return Mapper.Map<PosStatusSim,
                              PosStatusSimView>(posStatusSim);
        }
        
        
        public static IEnumerable<PosStatusSimView> ConvertToPosStatusSimViews(
                                                      this IEnumerable<PosStatusSim> posStatusSims)
        {
            return Mapper.Map<IEnumerable<PosStatusSim>, IEnumerable<PosStatusSimView>>(posStatusSims);
        }
        
        public static PosStatusSim ConvertToPosStatusSim(
                                               this PosStatusSimView posStatusSimView)
        {
            return Mapper.Map<PosStatusSimView,
                              PosStatusSim>(posStatusSimView);
        }
        
        
        public static IList<PosStatusSim> ConvertToPosStatusSims(
                                                      this IEnumerable<PosStatusSimView> posStatusSimsView)
        {
            return Mapper.Map<IEnumerable<PosStatusSimView>, IList<PosStatusSim>>(posStatusSimsView);
        }        
        
    }

}
