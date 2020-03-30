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
    public static class ProductFlatViewModelMapper
    {
        public static ProductFlatViewModel ConvertToProductFlatViewModel(
                                               this ProductView product)
        {
            return Mapper.Map<ProductView,
                              ProductFlatViewModel>(product);
        }
        
        
        public static IEnumerable<ProductFlatViewModel> ConvertToProductFlatViewModels(
                                                      this IEnumerable<ProductView> products)
        {
            return Mapper.Map<IEnumerable<ProductView>, IEnumerable<ProductFlatViewModel>>(products);
        }               

        public static ProductDetailView ConvertToProductDetailView(
                                               this ProductView product)
        {
            return Mapper.Map<ProductView,
                              ProductDetailView>(product);
        }
        
        
        public static IEnumerable<ProductDetailView> ConvertToProductDetailViews(
                                                      this IEnumerable<ProductView> products)
        {
            return Mapper.Map<IEnumerable<ProductView>, IEnumerable<ProductDetailView>>(products);
        }

        public static ModifyProductRequest ConvertToModifyProductRequest(
                                               this ProductView products)
        {
            return Mapper.Map<ProductView,
                              ModifyProductRequest>(products);
        }    	

        public static DetailProduct_ProductDetailView ConvertToDetailProduct_ProductDetailView(
                                       this ProductView products)
        {
            return Mapper.Map<ProductView,
                              DetailProduct_ProductDetailView>(products);
        }

        public static IEnumerable<DetailProduct_OrderDetailView> ConvertToDetailProductOrderDetailViews(
                                              this IEnumerable<OrderView> orders)
        {
            return Mapper.Map<IEnumerable<OrderView>, IEnumerable<DetailProduct_OrderDetailView>>(orders);
        }    	

    }

}
