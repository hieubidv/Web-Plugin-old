
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetSupplierResponse
    {
              public bool SupplierFound { get; set; }
              public SupplierView Supplier { get; set; }
    }
}
