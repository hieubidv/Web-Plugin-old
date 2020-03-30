using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  	
namespace ICreative.Controllers.ViewModels
{

    public class DetailPosMerchant_PosMerchantDetailView
    {
        public System.Int32 MerchantId { get; set; }
        public System.String MerchantName { get; set; }
        public System.String BusinessName { get; set; }
        public System.String BannerName { get; set; }
        public System.String MerchantIdByHeadQuater { get; set; }
    }

    public class DetailPosMerchant_PosReceiptOfTestingDetailView
    {
        public System.Int32 ReceiptOfTestingId { get; set; }
        public System.DateTime TestDate { get; set; }
        public System.String AgentAName { get; set; }
        public System.String AgentBName { get; set; }
        public System.Int32 PosId { get; set; }
        public System.Int32 PosMerchantMerchantId { get; set; }
        public System.String PosMerchantMerchantName { get; set; }
        public System.String PosMerchantBusinessName { get; set; }
        public System.String PosMerchantBannerName { get; set; }
        public System.String PosMerchantMerchantIdByHeadQuater { get; set; }
        public System.Int32 PosMerchantPosAddressAddressId { get; set; }
        public System.String PosMerchantPosAddressAddress { get; set; }
    }
}
