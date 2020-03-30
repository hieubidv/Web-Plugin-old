
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class PosAddressView
    {
        public System.Int32 AddressId  { get ; set; }  
		public System.String Address { get; set; }  
		public IList<PosMerchantView> PosMerchants { get; set; }  
    }
}


