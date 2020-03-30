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
    public static class CategoryFlatViewModelMapper
    {
        public static CategoryFlatViewModel ConvertToCategoryFlatViewModel(
                                               this CategoryView category)
        {
            return Mapper.Map<CategoryView,
                              CategoryFlatViewModel>(category);
        }
        
        
        public static IEnumerable<CategoryFlatViewModel> ConvertToCategoryFlatViewModels(
                                                      this IEnumerable<CategoryView> categories)
        {
            return Mapper.Map<IEnumerable<CategoryView>, IEnumerable<CategoryFlatViewModel>>(categories);
        }               

        public static CategoryDetailView ConvertToCategoryDetailView(
                                               this CategoryView category)
        {
            return Mapper.Map<CategoryView,
                              CategoryDetailView>(category);
        }
        
        
        public static IEnumerable<CategoryDetailView> ConvertToCategoryDetailViews(
                                                      this IEnumerable<CategoryView> categories)
        {
            return Mapper.Map<IEnumerable<CategoryView>, IEnumerable<CategoryDetailView>>(categories);
        }

        public static ModifyCategoryRequest ConvertToModifyCategoryRequest(
                                               this CategoryView categories)
        {
            return Mapper.Map<CategoryView,
                              ModifyCategoryRequest>(categories);
        }    	

        public static DetailCategory_CategoryDetailView ConvertToDetailCategory_CategoryDetailView(
                                       this CategoryView categories)
        {
            return Mapper.Map<CategoryView,
                              DetailCategory_CategoryDetailView>(categories);
        }

        public static IEnumerable<DetailCategory_ProductDetailView> ConvertToDetailCategoryProductDetailViews(
                                              this IEnumerable<ProductView> products)
        {
            return Mapper.Map<IEnumerable<ProductView>, IEnumerable<DetailCategory_ProductDetailView>>(products);
        }    	

    }

}
