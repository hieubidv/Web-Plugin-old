
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyPosAddressRequest
    {

        public System.Int32 AddressId  { get; set; }  
		public System.String Address { get; set; }  
		public IList<PosMerchantView> PosMerchants { get; set; }  
       
    }
}
