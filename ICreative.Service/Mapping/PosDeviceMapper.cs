
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PosDeviceMapper
    {
        public static PosDeviceView ConvertToPosDeviceView(
                                               this PosDevice posDevice)
        {
            return Mapper.Map<PosDevice,
                              PosDeviceView>(posDevice);
        }
        
        
        public static IEnumerable<PosDeviceView> ConvertToPosDeviceViews(
                                                      this IEnumerable<PosDevice> posDevices)
        {
            return Mapper.Map<IEnumerable<PosDevice>, IEnumerable<PosDeviceView>>(posDevices);
        }
        
        public static PosDevice ConvertToPosDevice(
                                               this PosDeviceView posDeviceView)
        {
            return Mapper.Map<PosDeviceView,
                              PosDevice>(posDeviceView);
        }
        
        
        public static IList<PosDevice> ConvertToPosDevices(
                                                      this IEnumerable<PosDeviceView> posDevicesView)
        {
            return Mapper.Map<IEnumerable<PosDeviceView>, IList<PosDevice>>(posDevicesView);
        }        
        
    }

}
