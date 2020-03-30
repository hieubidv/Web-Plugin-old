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
    public class MenuItemDetailController : Controller
    {
        private IMenuItemService _menuItemService;    
               
        public MenuItemDetailController(IMenuItemService menuItemService)
        {
             _menuItemService = menuItemService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/MenuItemDetail", id);
        }

        public JsonResult GetMenuItem(System.Int32 id)
        {
            DataTableViewModel data1;

            GetMenuItemRequest request = new GetMenuItemRequest();
            request.MenuItemId = id;
            DetailMenuItem_MenuItemDetailView data = _menuItemService.GetMenuItem(request).MenuItem.ConvertToDetailMenuItem_MenuItemDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        



        
    }
}
