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
    public class MenuItemTableController : Controller
    {

        private IMenuItemService _menuItemService;    
               
        public MenuItemTableController(IMenuItemService menuItemService)
        {
             _menuItemService = menuItemService;
        }
 
        public ActionResult Index()
        {
            MenuItemTableViewModel model = new MenuItemTableViewModel();
            return View("../Datatables/MenuItemTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<MenuItemFlatViewModel> menuItems;
            menuItems = _menuItemService.GetAllMenuItems().MenuItems.ConvertToMenuItemFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = menuItems.ToList().Count.ToString();
            data.recordsFiltered = menuItems.ToList().Count.ToString();

            data.data = menuItems.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            MenuItemDetailView vm = new MenuItemDetailView();
            GetMenuItemRequest request = new GetMenuItemRequest();
            request.MenuItemId = id;
            GetMenuItemResponse response = _menuItemService.GetMenuItem(request);
            if (response.MenuItemFound)
                vm = response.MenuItem.ConvertToMenuItemDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(MenuItemDetailView vm)
        {
            GetMenuItemRequest request = new GetMenuItemRequest();
            request.MenuItemId = vm.MenuItemId;
           
            ModifyMenuItemRequest updateRequest = _menuItemService.GetMenuItem(request).MenuItem.ConvertToModifyMenuItemRequest();

            updateRequest.MenuItemId = vm.MenuItemId;
            updateRequest.MenuItemName = vm.MenuItemName;
            updateRequest.ParentId = vm.ParentId;
            updateRequest.MenuItemUrl = vm.MenuItemUrl;

            ModifyMenuItemResponse response = _menuItemService.ModifyMenuItem(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(MenuItemDetailView vm)
        {
            CreateMenuItemRequest request = new CreateMenuItemRequest();
            request.MenuItemName = vm.MenuItemName;
            request.ParentId = vm.ParentId;
            request.MenuItemUrl = vm.MenuItemUrl;
            CreateMenuItemResponse response = _menuItemService.CreateMenuItem(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemoveMenuItemRequest request = new RemoveMenuItemRequest();
            request.MenuItemId = id;
            RemoveMenuItemResponse response = _menuItemService.RemoveMenuItem(request);
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

              //                  CreateMenuItemRequest request = new CreateMenuItemRequest();
             //                   request.MenuItemId = csvReader[0];
             //                   request.MenuItemName = csvReader[0];
             //                   request.ParentId = csvReader[0];
             //                   request.MenuItemUrl = csvReader[0];
             //                 CreateMenuItemResponse response = _menuItemService.CreateMenuItem(request);

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
