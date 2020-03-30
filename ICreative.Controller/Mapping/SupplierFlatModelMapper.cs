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
    public static class SupplierFlatViewModelMapper
    {
        public static SupplierFlatViewModel ConvertToSupplierFlatViewModel(
                                               this SupplierView supplier)
        {
            return Mapper.Map<SupplierView,
                              SupplierFlatViewModel>(supplier);
        }
        
        
        public static IEnumerable<SupplierFlatViewModel> ConvertToSupplierFlatViewModels(
                                                      this IEnumerable<SupplierView> suppliers)
        {
            return Mapper.Map<IEnumerable<SupplierView>, IEnumerable<SupplierFlatViewModel>>(suppliers);
        }               

        public static SupplierDetailView ConvertToSupplierDetailView(
                                               this SupplierView supplier)
        {
            return Mapper.Map<SupplierView,
                              SupplierDetailView>(supplier);
        }
        
        
        public static IEnumerable<SupplierDetailView> ConvertToSupplierDetailViews(
                                                      this IEnumerable<SupplierView> suppliers)
        {
            return Mapper.Map<IEnumerable<SupplierView>, IEnumerable<SupplierDetailView>>(suppliers);
        }

        public static ModifySupplierRequest ConvertToModifySupplierRequest(
                                               this SupplierView suppliers)
        {
            return Mapper.Map<SupplierView,
                              ModifySupplierRequest>(suppliers);
        }    	

        public static DetailSupplier_SupplierDetailView ConvertToDetailSupplier_SupplierDetailView(
                                       this SupplierView suppliers)
        {
            return Mapper.Map<SupplierView,
                              DetailSupplier_SupplierDetailView>(suppliers);
        }

        public static IEnumerable<DetailSupplier_ProductDetailView> ConvertToDetailSupplierProductDetailViews(
                                              this IEnumerable<ProductView> products)
        {
            return Mapper.Map<IEnumerable<ProductView>, IEnumerable<DetailSupplier_ProductDetailView>>(products);
        }    	

    }

}
