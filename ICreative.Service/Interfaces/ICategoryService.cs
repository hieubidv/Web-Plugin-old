
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface ICategoryService
    {
        CreateCategoryResponse CreateCategory(CreateCategoryRequest request);
        GetCategoryResponse GetCategory(GetCategoryRequest request);
        GetAllCategoryResponse GetAllCategories();
        ModifyCategoryResponse ModifyCategory(ModifyCategoryRequest request);
        RemoveCategoryResponse RemoveCategory(RemoveCategoryRequest request);
    }

}
