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
    public static class PosDeviceFlatViewModelMapper
    {
        public static PosDeviceFlatViewModel ConvertToPosDeviceFlatViewModel(
                                               this PosDeviceView posDevice)
        {
            return Mapper.Map<PosDeviceView,
                              PosDeviceFlatViewModel>(posDevice);
        }
        
        
        public static IEnumerable<PosDeviceFlatViewModel> ConvertToPosDeviceFlatViewModels(
                                                      this IEnumerable<PosDeviceView> posDevices)
        {
            return Mapper.Map<IEnumerable<PosDeviceView>, IEnumerable<PosDeviceFlatViewModel>>(posDevices);
        }               

        public static PosDeviceDetailView ConvertToPosDeviceDetailView(
                                               this PosDeviceView posDevice)
        {
            return Mapper.Map<PosDeviceView,
                              PosDeviceDetailView>(posDevice);
        }
        
        
        public static IEnumerable<PosDeviceDetailView> ConvertToPosDeviceDetailViews(
                                                      this IEnumerable<PosDeviceView> posDevices)
        {
            return Mapper.Map<IEnumerable<PosDeviceView>, IEnumerable<PosDeviceDetailView>>(posDevices);
        }

        public static ModifyPosDeviceRequest ConvertToModifyPosDeviceRequest(
                                               this PosDeviceView posDevices)
        {
            return Mapper.Map<PosDeviceView,
                              ModifyPosDeviceRequest>(posDevices);
        }    	

        public static DetailPosDevice_PosDeviceDetailView ConvertToDetailPosDevice_PosDeviceDetailView(
                                       this PosDeviceView posDevices)
        {
            return Mapper.Map<PosDeviceView,
                              DetailPosDevice_PosDeviceDetailView>(posDevices);
        }

        public static IEnumerable<DetailPosDevice_PosTerminalDetailView> ConvertToDetailPosDevicePosTerminalDetailViews(
                                              this IEnumerable<PosTerminalView> posTerminals)
        {
            return Mapper.Map<IEnumerable<PosTerminalView>, IEnumerable<DetailPosDevice_PosTerminalDetailView>>(posTerminals);
        }    	

    }

}
