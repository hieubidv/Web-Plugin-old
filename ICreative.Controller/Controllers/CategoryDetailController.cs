using ICreative.Controllers.Datatables;
using ICreative.Controllers.Mapping;
using ICreative.Controllers.ViewModels;
using ICreative.Services.Interfaces;
using ICreative.Services.Messaging;
using ICreative.Services.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ICreative.Controllers.Controllers
{
    public class CategoryDetailController : Controller
    {
        private ICategoryService _categoryService;    
               
        public CategoryDetailController(ICategoryService categoryService)
        {
             _categoryService = categoryService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/CategoryDetail", id);
        }

        public JsonResult GetCategory(System.Int32 id)
        {
            DataTableViewModel data1;

            GetCategoryRequest request = new GetCategoryRequest();
            request.CategoryID = id;
            DetailCategory_CategoryDetailView data = _categoryService.GetCategory(request).Category.ConvertToDetailCategory_CategoryDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetProductDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetCategoryRequest request = new GetCategoryRequest();
            request.CategoryID = id;
            CategoryView category = _categoryService.GetCategory(request).Category;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = category.Products.ToList().Count.ToString();
            data.recordsFiltered = category.Products.ToList().Count.ToString();

            data.data = category.Products.ConvertToDetailCategoryProductDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
