using System;
using System.Web.Mvc;
using System.Linq;
using ICreative.Services.Interfaces;
using ICreative.Services.ViewModels;
using ICreative.Controllers.ViewModels;
using System.Collections.Generic;
using ICreative.Controllers.Mapping;
using ICreative.Controllers.Datatables;
using ICreative.Services.Messaging;
using ICreative.Controllers.ViewModels.Datatable;
using System.Web;
using System.IO;
namespace ICreative.Controllers.Controllers
{
    public class CategoryTableController : Controller
    {

        private ICategoryService _categoryService;    
               
        public CategoryTableController(ICategoryService categoryService)
        {
             _categoryService = categoryService;
        }
 
        public ActionResult Index()
        {
            CategoryTableViewModel model = new CategoryTableViewModel();
            return View("../Datatables/CategoryTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<CategoryFlatViewModel> categories;
            categories = _categoryService.GetAllCategories().Categories.ConvertToCategoryFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = categories.ToList().Count.ToString();
            data.recordsFiltered = categories.ToList().Count.ToString();

            data.data = categories.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            CategoryDetailView vm = new CategoryDetailView();
            GetCategoryRequest request = new GetCategoryRequest();
            request.CategoryID = id;
            GetCategoryResponse response = _categoryService.GetCategory(request);
            if (response.CategoryFound)
                vm = response.Category.ConvertToCategoryDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(CategoryDetailView vm)
        {
            GetCategoryRequest request = new GetCategoryRequest();
            request.CategoryID = vm.CategoryID;
           
            ModifyCategoryRequest updateRequest = _categoryService.GetCategory(request).Category.ConvertToModifyCategoryRequest();

            updateRequest.CategoryID = vm.CategoryID;
            updateRequest.CategoryName = vm.CategoryName;
            updateRequest.Description = vm.Description;
            updateRequest.Picture = vm.Picture;

            ModifyCategoryResponse response = _categoryService.ModifyCategory(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(CategoryDetailView vm)
        {
            CreateCategoryRequest request = new CreateCategoryRequest();
            request.CategoryName = vm.CategoryName;
            request.Description = vm.Description;
            request.Picture = vm.Picture;
            CreateCategoryResponse response = _categoryService.CreateCategory(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveCategoryRequest request = new RemoveCategoryRequest();
            request.CategoryID = id;
            RemoveCategoryResponse response = _categoryService.RemoveCategory(request);
            return Json(response);
        }
        
        
        
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase uploadedFile)
        {
            try
            {
                if (uploadedFile.ContentLength > 0)
                {
                    if (uploadedFile.FileName.EndsWith(".csv"))
                    {
                        Stream stream = uploadedFile.InputStream;
              //          using (CsvReader csvReader =
              //              new CsvReader(new StreamReader(stream), true))
              //          {
              //              while (csvReader.ReadNextRecord())
              //              {

              //                  CreateCategoryRequest request = new CreateCategoryRequest();
             //                   request.CategoryID = csvReader[0];
             //                   request.CategoryName = csvReader[0];
             //                   request.Description = csvReader[0];
             //                   request.Picture = csvReader[0];
             //                 CreateCategoryResponse response = _categoryService.CreateCategory(request);

             //               }
             //           }                     
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");                     
                    }
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }        
        
    }
}
