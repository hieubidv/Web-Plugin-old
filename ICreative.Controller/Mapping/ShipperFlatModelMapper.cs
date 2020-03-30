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
    public static class ShipperFlatViewModelMapper
    {
        public static ShipperFlatViewModel ConvertToShipperFlatViewModel(
                                               this ShipperView shipper)
        {
            return Mapper.Map<ShipperView,
                              ShipperFlatViewModel>(shipper);
        }
        
        
        public static IEnumerable<ShipperFlatViewModel> ConvertToShipperFlatViewModels(
                                                      this IEnumerable<ShipperView> shippers)
        {
            return Mapper.Map<IEnumerable<ShipperView>, IEnumerable<ShipperFlatViewModel>>(shippers);
        }               

        public static ShipperDetailView ConvertToShipperDetailView(
                                               this ShipperView shipper)
        {
            return Mapper.Map<ShipperView,
                              ShipperDetailView>(shipper);
        }
        
        
        public static IEnumerable<ShipperDetailView> ConvertToShipperDetailViews(
                                                      this IEnumerable<ShipperView> shippers)
        {
            return Mapper.Map<IEnumerable<ShipperView>, IEnumerable<ShipperDetailView>>(shippers);
        }

        public static ModifyShipperRequest ConvertToModifyShipperRequest(
                                               this ShipperView shippers)
        {
            return Mapper.Map<ShipperView,
                              ModifyShipperRequest>(shippers);
        }    	

        public static DetailShipper_ShipperDetailView ConvertToDetailShipper_ShipperDetailView(
                                       this ShipperView shippers)
        {
            return Mapper.Map<ShipperView,
                              DetailShipper_ShipperDetailView>(shippers);
        }

        public static IEnumerable<DetailShipper_OrderDetailView> ConvertToDetailShipperOrderDetailViews(
                                              this IEnumerable<OrderView> orders)
        {
            return Mapper.Map<IEnumerable<OrderView>, IEnumerable<DetailShipper_OrderDetailView>>(orders);
        }    	

    }

}
