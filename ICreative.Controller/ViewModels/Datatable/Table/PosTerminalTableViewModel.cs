﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace ICreative.Controllers.ViewModels.Datatable
{
    public class PosTerminalTableViewModel
    {
      public  List<SelectListItem> PosDevices { get; set; }
      public  List<SelectListItem> PosStatusTerminals { get; set; }
      public  List<SelectListItem> PosSims { get; set; }
    }
}
