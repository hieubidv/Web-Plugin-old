
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class OrderMapper
    {
        public static OrderView ConvertToOrderView(
                                               this Order order)
        {
            return Mapper.Map<Order,
                              OrderView>(order);
        }
        
        
        public static IEnumerable<OrderView> ConvertToOrderViews(
                                                      this IEnumerable<Order> orders)
        {
            return Mapper.Map<IEnumerable<Order>, IEnumerable<OrderView>>(orders);
        }
        
        public static Order ConvertToOrder(
                                               this OrderView orderView)
        {
            return Mapper.Map<OrderView,
                              Order>(orderView);
        }
        
        
        public static IList<Order> ConvertToOrders(
                                                      this IEnumerable<OrderView> ordersView)
        {
            return Mapper.Map<IEnumerable<OrderView>, IList<Order>>(ordersView);
        }        
        
    }

}
