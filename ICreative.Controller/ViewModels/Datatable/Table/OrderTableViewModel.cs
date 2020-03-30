using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace ICreative.Controllers.ViewModels.Datatable
{
    public class OrderTableViewModel
    {
      public  List<SelectListItem> Employees { get; set; }
      public  List<SelectListItem> Customers { get; set; }
      public  List<SelectListItem> Shippers { get; set; }
    }
}
