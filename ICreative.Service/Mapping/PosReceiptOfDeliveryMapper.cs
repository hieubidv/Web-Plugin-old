
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PosReceiptOfDeliveryMapper
    {
        public static PosReceiptOfDeliveryView ConvertToPosReceiptOfDeliveryView(
                                               this PosReceiptOfDelivery posReceiptOfDelivery)
        {
            return Mapper.Map<PosReceiptOfDelivery,
                              PosReceiptOfDeliveryView>(posReceiptOfDelivery);
        }
        
        
        public static IEnumerable<PosReceiptOfDeliveryView> ConvertToPosReceiptOfDeliveryViews(
                                                      this IEnumerable<PosReceiptOfDelivery> posReceiptOfDeliveries)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfDelivery>, IEnumerable<PosReceiptOfDeliveryView>>(posReceiptOfDeliveries);
        }
        
        public static PosReceiptOfDelivery ConvertToPosReceiptOfDelivery(
                                               this PosReceiptOfDeliveryView posReceiptOfDeliveryView)
        {
            return Mapper.Map<PosReceiptOfDeliveryView,
                              PosReceiptOfDelivery>(posReceiptOfDeliveryView);
        }
        
        
        public static IList<PosReceiptOfDelivery> ConvertToPosReceiptOfDeliveries(
                                                      this IEnumerable<PosReceiptOfDeliveryView> posReceiptOfDeliveriesView)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfDeliveryView>, IList<PosReceiptOfDelivery>>(posReceiptOfDeliveriesView);
        }        
        
    }

}
