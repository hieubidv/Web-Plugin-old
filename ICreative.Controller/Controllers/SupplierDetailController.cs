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
    public class SupplierDetailController : Controller
    {
        private ISupplierService _supplierService;    
               
        public SupplierDetailController(ISupplierService supplierService)
        {
             _supplierService = supplierService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/SupplierDetail", id);
        }

        public JsonResult GetSupplier(System.Int32 id)
        {
            DataTableViewModel data1;

            GetSupplierRequest request = new GetSupplierRequest();
            request.SupplierID = id;
            DetailSupplier_SupplierDetailView data = _supplierService.GetSupplier(request).Supplier.ConvertToDetailSupplier_SupplierDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetProductDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetSupplierRequest request = new GetSupplierRequest();
            request.SupplierID = id;
            SupplierView supplier = _supplierService.GetSupplier(request).Supplier;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = supplier.Products.ToList().Count.ToString();
            data.recordsFiltered = supplier.Products.ToList().Count.ToString();

            data.data = supplier.Products.ConvertToDetailSupplierProductDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
