
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PosStatusTerminalMapper
    {
        public static PosStatusTerminalView ConvertToPosStatusTerminalView(
                                               this PosStatusTerminal posStatusTerminal)
        {
            return Mapper.Map<PosStatusTerminal,
                              PosStatusTerminalView>(posStatusTerminal);
        }
        
        
        public static IEnumerable<PosStatusTerminalView> ConvertToPosStatusTerminalViews(
                                                      this IEnumerable<PosStatusTerminal> posStatusTerminals)
        {
            return Mapper.Map<IEnumerable<PosStatusTerminal>, IEnumerable<PosStatusTerminalView>>(posStatusTerminals);
        }
        
        public static PosStatusTerminal ConvertToPosStatusTerminal(
                                               this PosStatusTerminalView posStatusTerminalView)
        {
            return Mapper.Map<PosStatusTerminalView,
                              PosStatusTerminal>(posStatusTerminalView);
        }
        
        
        public static IList<PosStatusTerminal> ConvertToPosStatusTerminals(
                                                      this IEnumerable<PosStatusTerminalView> posStatusTerminalsView)
        {
            return Mapper.Map<IEnumerable<PosStatusTerminalView>, IList<PosStatusTerminal>>(posStatusTerminalsView);
        }        
        
    }

}
