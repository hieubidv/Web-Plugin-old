
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class ShipperMapper
    {
        public static ShipperView ConvertToShipperView(
                                               this Shipper shipper)
        {
            return Mapper.Map<Shipper,
                              ShipperView>(shipper);
        }
        
        
        public static IEnumerable<ShipperView> ConvertToShipperViews(
                                                      this IEnumerable<Shipper> shippers)
        {
            return Mapper.Map<IEnumerable<Shipper>, IEnumerable<ShipperView>>(shippers);
        }
        
        public static Shipper ConvertToShipper(
                                               this ShipperView shipperView)
        {
            return Mapper.Map<ShipperView,
                              Shipper>(shipperView);
        }
        
        
        public static IList<Shipper> ConvertToShippers(
                                                      this IEnumerable<ShipperView> shippersView)
        {
            return Mapper.Map<IEnumerable<ShipperView>, IList<Shipper>>(shippersView);
        }        
        
    }

}
