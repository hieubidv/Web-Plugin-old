
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class CategoryMapper
    {
        public static CategoryView ConvertToCategoryView(
                                               this Category category)
        {
            return Mapper.Map<Category,
                              CategoryView>(category);
        }
        
        
        public static IEnumerable<CategoryView> ConvertToCategoryViews(
                                                      this IEnumerable<Category> categories)
        {
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryView>>(categories);
        }
        
        public static Category ConvertToCategory(
                                               this CategoryView categoryView)
        {
            return Mapper.Map<CategoryView,
                              Category>(categoryView);
        }
        
        
        public static IList<Category> ConvertToCategories(
                                                      this IEnumerable<CategoryView> categoriesView)
        {
            return Mapper.Map<IEnumerable<CategoryView>, IList<Category>>(categoriesView);
        }        
        
    }

}
