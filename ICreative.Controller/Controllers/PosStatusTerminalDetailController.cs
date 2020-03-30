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
    public class PosStatusTerminalDetailController : Controller
    {
        private IPosStatusTerminalService _posStatusTerminalService;    
               
        public PosStatusTerminalDetailController(IPosStatusTerminalService posStatusTerminalService)
        {
             _posStatusTerminalService = posStatusTerminalService;
        }
        
                
 
        public ActionResult Detail(System.Int32 id)
        {
            return View("../Details/PosStatusTerminalDetail", id);
        }

        public JsonResult GetPosStatusTerminal(System.Int32 id)
        {
            DataTableViewModel data1;

            GetPosStatusTerminalRequest request = new GetPosStatusTerminalRequest();
            request.TerminalStatusId = id;
            DetailPosStatusTerminal_PosStatusTerminalDetailView data = _posStatusTerminalService.GetPosStatusTerminal(request).PosStatusTerminal.ConvertToDetailPosStatusTerminal_PosStatusTerminalDetailView();

            return Json(data, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult GetPosTerminalDataTable(System.Int32 id)
        {
            DataTableViewModel data;

            GetPosStatusTerminalRequest request = new GetPosStatusTerminalRequest();
            request.TerminalStatusId = id;
            PosStatusTerminalView posStatusTerminal = _posStatusTerminalService.GetPosStatusTerminal(request).PosStatusTerminal;

            data = new DataTableViewModel();
            data.draw = "1";
            data.recordsTotal = posStatusTerminal.PosTerminals.ToList().Count.ToString();
            data.recordsFiltered = posStatusTerminal.PosTerminals.ToList().Count.ToString();

            data.data = posStatusTerminal.PosTerminals.ConvertToDetailPosStatusTerminalPosTerminalDetailViews().ToList<object>();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        
    }
}
