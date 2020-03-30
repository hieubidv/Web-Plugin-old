
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreatePosMerchantRequest
    {
		public System.String MerchantName { get; set; }  
		public System.String BusinessName { get; set; }  
		public System.String BannerName { get; set; }  
		public System.String MerchantIdByHeadQuater { get; set; }  
		public IList<PosReceiptOfTestingView> PosReceiptOfTestings { get; set; }  
		public PosAddressView PosAddress { get; set; }  
    }
}
