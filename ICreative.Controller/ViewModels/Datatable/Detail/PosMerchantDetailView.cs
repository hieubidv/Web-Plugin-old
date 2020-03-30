using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class PosMerchantDetailView
    {
        public System.Int32 MerchantId { get; set; }
        public System.String MerchantName { get; set; }
        public System.Int32 PosAddressAddressId { get; set; }
        public System.String BusinessName { get; set; }
        public System.String BannerName { get; set; }
        public System.String MerchantIdByHeadQuater { get; set; }
    }
}
