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
    public class ProductDetailController : Controller
    {
        private ICategoryService _categoryService;
private IProductService _productService;
private ISupplierService _supplierService;    
               
        public ProductDetailController(ICategoryService categoryService,IProductService productService,ISupplierService supplierService)
        {
             _categoryService = categoryService;
_productService = productService;
_supplierService = supplierService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/ProductDetail", id);
        }

        public JsonResult GetProduct(System.Int32 id)
        {
            DataTableViewModel data1;

            GetProductRequest request = new GetProductRequest();
            request.ProductID = id;
            DetailProduct_ProductDetailView data = _productService.GetProduct(request).Product.ConvertToDetailProduct_ProductDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetOrderDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetProductRequest request = new GetProductRequest();
            request.ProductID = id;
            ProductView product = _productService.GetProduct(request).Product;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = product.Orders.ToList().Count.ToString();
            data.recordsFiltered = product.Orders.ToList().Count.ToString();

            data.data = product.Orders.ConvertToDetailProductOrderDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
