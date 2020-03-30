
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllSupplierResponse
    {
              public bool SupplierFound { get; set; }
              public IEnumerable<SupplierView> Suppliers { get; set; }
    }
}
