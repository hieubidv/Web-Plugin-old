﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace ICreative.Controllers.ViewModels.Datatable
{
    public class ProductTableViewModel
    {
      public  List<SelectListItem> Categories { get; set; }
      public  List<SelectListItem> Suppliers { get; set; }
    }
}
