
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PosSimMapper
    {
        public static PosSimView ConvertToPosSimView(
                                               this PosSim posSim)
        {
            return Mapper.Map<PosSim,
                              PosSimView>(posSim);
        }
        
        
        public static IEnumerable<PosSimView> ConvertToPosSimViews(
                                                      this IEnumerable<PosSim> posSims)
        {
            return Mapper.Map<IEnumerable<PosSim>, IEnumerable<PosSimView>>(posSims);
        }
        
        public static PosSim ConvertToPosSim(
                                               this PosSimView posSimView)
        {
            return Mapper.Map<PosSimView,
                              PosSim>(posSimView);
        }
        
        
        public static IList<PosSim> ConvertToPosSims(
                                                      this IEnumerable<PosSimView> posSimsView)
        {
            return Mapper.Map<IEnumerable<PosSimView>, IList<PosSim>>(posSimsView);
        }        
        
    }

}
