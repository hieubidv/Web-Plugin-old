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
    public static class OrderFlatViewModelMapper
    {
        public static OrderFlatViewModel ConvertToOrderFlatViewModel(
                                               this OrderView order)
        {
            return Mapper.Map<OrderView,
                              OrderFlatViewModel>(order);
        }
        
        
        public static IEnumerable<OrderFlatViewModel> ConvertToOrderFlatViewModels(
                                                      this IEnumerable<OrderView> orders)
        {
            return Mapper.Map<IEnumerable<OrderView>, IEnumerable<OrderFlatViewModel>>(orders);
        }               

        public static OrderDetailView ConvertToOrderDetailView(
                                               this OrderView order)
        {
            return Mapper.Map<OrderView,
                              OrderDetailView>(order);
        }
        
        
        public static IEnumerable<OrderDetailView> ConvertToOrderDetailViews(
                                                      this IEnumerable<OrderView> orders)
        {
            return Mapper.Map<IEnumerable<OrderView>, IEnumerable<OrderDetailView>>(orders);
        }

        public static ModifyOrderRequest ConvertToModifyOrderRequest(
                                               this OrderView orders)
        {
            return Mapper.Map<OrderView,
                              ModifyOrderRequest>(orders);
        }    	

        public static DetailOrder_OrderDetailView ConvertToDetailOrder_OrderDetailView(
                                       this OrderView orders)
        {
            return Mapper.Map<OrderView,
                              DetailOrder_OrderDetailView>(orders);
        }

        public static IEnumerable<DetailOrder_ProductDetailView> ConvertToDetailOrderProductDetailViews(
                                              this IEnumerable<ProductView> products)
        {
            return Mapper.Map<IEnumerable<ProductView>, IEnumerable<DetailOrder_ProductDetailView>>(products);
        }    	

    }

}
