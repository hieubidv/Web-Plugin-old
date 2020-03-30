
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PosTerminalMapper
    {
        public static PosTerminalView ConvertToPosTerminalView(
                                               this PosTerminal posTerminal)
        {
            return Mapper.Map<PosTerminal,
                              PosTerminalView>(posTerminal);
        }
        
        
        public static IEnumerable<PosTerminalView> ConvertToPosTerminalViews(
                                                      this IEnumerable<PosTerminal> posTerminals)
        {
            return Mapper.Map<IEnumerable<PosTerminal>, IEnumerable<PosTerminalView>>(posTerminals);
        }
        
        public static PosTerminal ConvertToPosTerminal(
                                               this PosTerminalView posTerminalView)
        {
            return Mapper.Map<PosTerminalView,
                              PosTerminal>(posTerminalView);
        }
        
        
        public static IList<PosTerminal> ConvertToPosTerminals(
                                                      this IEnumerable<PosTerminalView> posTerminalsView)
        {
            return Mapper.Map<IEnumerable<PosTerminalView>, IList<PosTerminal>>(posTerminalsView);
        }        
        
    }

}
