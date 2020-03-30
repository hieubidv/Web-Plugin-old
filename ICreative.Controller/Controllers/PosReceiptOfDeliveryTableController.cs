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
    public class PosReceiptOfDeliveryTableController : Controller
    {

        private IPosReceiptOfDeliveryService _posReceiptOfDeliveryService;
private IUserService _userService;    
               
        public PosReceiptOfDeliveryTableController(IPosReceiptOfDeliveryService posReceiptOfDeliveryService,IUserService userService)
        {
             _posReceiptOfDeliveryService = posReceiptOfDeliveryService;
_userService = userService;
        }
 
        public ActionResult Index()
        {
            PosReceiptOfDeliveryTableViewModel model = new PosReceiptOfDeliveryTableViewModel();
            model.Users = _userService.GetAllUsers().Users.Select(u=>new SelectListItem() { Text = u.UserName, Value = u.UserId.ToString()}).ToList();
            return View("../Datatables/PosReceiptOfDeliveryTable",model);
        }



        public JsonResult GetAllRows()
        {
            IEnumerable<PosReceiptOfDeliveryFlatViewModel> posReceiptOfDeliveries;
            posReceiptOfDeliveries = _posReceiptOfDeliveryService.GetAllPosReceiptOfDeliveries().PosReceiptOfDeliveries.ConvertToPosReceiptOfDeliveryFlatViewModels();
            DataTableViewModel data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posReceiptOfDeliveries.ToList().Count.ToString();
            data.recordsFiltered = posReceiptOfDeliveries.ToList().Count.ToString();

            data.data = posReceiptOfDeliveries.ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(System.Int32 id)
        {  
            PosReceiptOfDeliveryDetailView vm = new PosReceiptOfDeliveryDetailView();
            GetPosReceiptOfDeliveryRequest request = new GetPosReceiptOfDeliveryRequest();
            request.PosReceiptOfDeliveryId = id;
            GetPosReceiptOfDeliveryResponse response = _posReceiptOfDeliveryService.GetPosReceiptOfDelivery(request);
            if (response.PosReceiptOfDeliveryFound)
                vm = response.PosReceiptOfDelivery.ConvertToPosReceiptOfDeliveryDetailView();          

            return Json(vm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PosReceiptOfDeliveryDetailView vm)
        {
            GetPosReceiptOfDeliveryRequest request = new GetPosReceiptOfDeliveryRequest();
            request.PosReceiptOfDeliveryId = vm.PosReceiptOfDeliveryId;
           
            ModifyPosReceiptOfDeliveryRequest updateRequest = _posReceiptOfDeliveryService.GetPosReceiptOfDelivery(request).PosReceiptOfDelivery.ConvertToModifyPosReceiptOfDeliveryRequest();

            updateRequest.PosReceiptOfDeliveryId = vm.PosReceiptOfDeliveryId;
            updateRequest.DeliveryDate = vm.DeliveryDate;
               GetUserRequest userRequest = new GetUserRequest();
            userRequest.UserId = vm.UserUserId;
            updateRequest.User = _userService.GetUser(userRequest).User;            
            updateRequest.ReceiverName = vm.ReceiverName;

            ModifyPosReceiptOfDeliveryResponse response = _posReceiptOfDeliveryService.ModifyPosReceiptOfDelivery(updateRequest);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Create(PosReceiptOfDeliveryDetailView vm)
        {
            CreatePosReceiptOfDeliveryRequest request = new CreatePosReceiptOfDeliveryRequest();
            request.DeliveryDate = vm.DeliveryDate;
               GetUserRequest userRequest = new GetUserRequest();
            userRequest.UserId = vm.UserUserId;
            request.User = _userService.GetUser(userRequest).User;            
            request.ReceiverName = vm.ReceiverName;
            CreatePosReceiptOfDeliveryResponse response = _posReceiptOfDeliveryService.CreatePosReceiptOfDelivery(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(System.Int32 id)
        {
            RemovePosReceiptOfDeliveryRequest request = new RemovePosReceiptOfDeliveryRequest();
            request.PosReceiptOfDeliveryId = id;
            RemovePosReceiptOfDeliveryResponse response = _posReceiptOfDeliveryService.RemovePosReceiptOfDelivery(request);
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

              //                  CreatePosReceiptOfDeliveryRequest request = new CreatePosReceiptOfDeliveryRequest();
             //                   request.PosReceiptOfDeliveryId = csvReader[0];
             //                   request.DeliveryDate = csvReader[0];
             //                   request.UserUserId = csvReader[0];
             //                   request.ReceiverName = csvReader[0];
             //                 CreatePosReceiptOfDeliveryResponse response = _posReceiptOfDeliveryService.CreatePosReceiptOfDelivery(request);

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
