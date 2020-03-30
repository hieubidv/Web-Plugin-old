
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllPosMerchantResponse
    {
              public bool PosMerchantFound { get; set; }
              public IEnumerable<PosMerchantView> PosMerchants { get; set; }
    }
}
