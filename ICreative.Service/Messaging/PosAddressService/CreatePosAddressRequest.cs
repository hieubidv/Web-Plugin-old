
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreatePosAddressRequest
    {
		public System.String Address { get; set; }  
		public IList<PosMerchantView> PosMerchants { get; set; }  
    }
}
