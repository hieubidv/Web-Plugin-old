
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class ProductMapper
    {
        public static ProductView ConvertToProductView(
                                               this Product product)
        {
            return Mapper.Map<Product,
                              ProductView>(product);
        }
        
        
        public static IEnumerable<ProductView> ConvertToProductViews(
                                                      this IEnumerable<Product> products)
        {
            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductView>>(products);
        }
        
        public static Product ConvertToProduct(
                                               this ProductView productView)
        {
            return Mapper.Map<ProductView,
                              Product>(productView);
        }
        
        
        public static IList<Product> ConvertToProducts(
                                                      this IEnumerable<ProductView> productsView)
        {
            return Mapper.Map<IEnumerable<ProductView>, IList<Product>>(productsView);
        }        
        
    }

}
