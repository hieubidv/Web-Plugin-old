
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class SupplierMapper
    {
        public static SupplierView ConvertToSupplierView(
                                               this Supplier supplier)
        {
            return Mapper.Map<Supplier,
                              SupplierView>(supplier);
        }
        
        
        public static IEnumerable<SupplierView> ConvertToSupplierViews(
                                                      this IEnumerable<Supplier> suppliers)
        {
            return Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierView>>(suppliers);
        }
        
        public static Supplier ConvertToSupplier(
                                               this SupplierView supplierView)
        {
            return Mapper.Map<SupplierView,
                              Supplier>(supplierView);
        }
        
        
        public static IList<Supplier> ConvertToSuppliers(
                                                      this IEnumerable<SupplierView> suppliersView)
        {
            return Mapper.Map<IEnumerable<SupplierView>, IList<Supplier>>(suppliersView);
        }        
        
    }

}
