
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetProductResponse
    {
              public bool ProductFound { get; set; }
              public ProductView Product { get; set; }
    }
}
