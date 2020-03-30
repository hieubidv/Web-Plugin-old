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
    public class ProductTableController : Controller
    {

        private ICategoryService _categoryService;
private IProductService _productService;
private ISupplierService _supplierService;    
               
        public ProductTableController(ICategoryService categoryService,IProductService productService,ISupplierService supplierService)
        {
             _categoryService = categoryService;
_productService = productService;
_supplierService = supplierService;
        }
 
        public ActionResult Index()
        {
            ProductTableViewModel model = new ProductTableViewModel();
            model.Categories = _categoryService.GetAllCategories().Categories.Select(u=>new SelectListItem() { Text = u.CategoryName, Value = u.CategoryID.ToString()}).ToList();
            model.Suppliers = _supplierService.GetAllSuppliers().Suppliers.Select(u=>new SelectListItem() { Text = u.CompanyName, Value = u.SupplierID.ToString()}).ToList();
            return View("../Datatables/ProductTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<ProductFlatViewModel> products;
            products = _productService.GetAllProducts().Products.ConvertToProductFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = products.ToList().Count.ToString();
            data.recordsFiltered = products.ToList().Count.ToString();

            data.data = products.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            ProductDetailView vm = new ProductDetailView();
            GetProductRequest request = new GetProductRequest();
            request.ProductID = id;
            GetProductResponse response = _productService.GetProduct(request);
            if (response.ProductFound)
                vm = response.Product.ConvertToProductDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(ProductDetailView vm)
        {
            GetProductRequest request = new GetProductRequest();
            request.ProductID = vm.ProductID;
           
            ModifyProductRequest updateRequest = _productService.GetProduct(request).Product.ConvertToModifyProductRequest();

            updateRequest.ProductID = vm.ProductID;
            updateRequest.ProductName = vm.ProductName;
               GetSupplierRequest supplierRequest = new GetSupplierRequest();
            supplierRequest.SupplierID = vm.SupplierSupplierID;
            updateRequest.Supplier = _supplierService.GetSupplier(supplierRequest).Supplier;            
               GetCategoryRequest categoryRequest = new GetCategoryRequest();
            categoryRequest.CategoryID = vm.CategoryCategoryID;
            updateRequest.Category = _categoryService.GetCategory(categoryRequest).Category;            
            updateRequest.QuantityPerUnit = vm.QuantityPerUnit;
            updateRequest.UnitPrice = vm.UnitPrice;
            updateRequest.UnitsInStock = vm.UnitsInStock;
            updateRequest.UnitsOnOrder = vm.UnitsOnOrder;
            updateRequest.ReorderLevel = vm.ReorderLevel;
            updateRequest.Discontinued = vm.Discontinued;

            ModifyProductResponse response = _productService.ModifyProduct(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(ProductDetailView vm)
        {
            CreateProductRequest request = new CreateProductRequest();
            request.ProductName = vm.ProductName;
               GetSupplierRequest supplierRequest = new GetSupplierRequest();
            supplierRequest.SupplierID = vm.SupplierSupplierID;
            request.Supplier = _supplierService.GetSupplier(supplierRequest).Supplier;            
               GetCategoryRequest categoryRequest = new GetCategoryRequest();
            categoryRequest.CategoryID = vm.CategoryCategoryID;
            request.Category = _categoryService.GetCategory(categoryRequest).Category;            
            request.QuantityPerUnit = vm.QuantityPerUnit;
            request.UnitPrice = vm.UnitPrice;
            request.UnitsInStock = vm.UnitsInStock;
            request.UnitsOnOrder = vm.UnitsOnOrder;
            request.ReorderLevel = vm.ReorderLevel;
            request.Discontinued = vm.Discontinued;
            CreateProductResponse response = _productService.CreateProduct(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveProductRequest request = new RemoveProductRequest();
            request.ProductID = id;
            RemoveProductResponse response = _productService.RemoveProduct(request);
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

              //                  CreateProductRequest request = new CreateProductRequest();
             //                   request.ProductID = csvReader[0];
             //                   request.ProductName = csvReader[0];
             //                   request.SupplierSupplierID = csvReader[0];
             //                   request.CategoryCategoryID = csvReader[0];
             //                   request.QuantityPerUnit = csvReader[0];
             //                   request.UnitPrice = csvReader[0];
             //                   request.UnitsInStock = csvReader[0];
             //                   request.UnitsOnOrder = csvReader[0];
             //                   request.ReorderLevel = csvReader[0];
             //                   request.Discontinued = csvReader[0];
             //                 CreateProductResponse response = _productService.CreateProduct(request);

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
