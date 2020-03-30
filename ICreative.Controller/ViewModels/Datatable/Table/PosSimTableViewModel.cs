using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace ICreative.Controllers.ViewModels.Datatable
{
    public class PosSimTableViewModel
    {
      public  List<SelectListItem> PosStatusSims { get; set; }
      public  List<SelectListItem> PosSimProviders { get; set; }
    }
}
