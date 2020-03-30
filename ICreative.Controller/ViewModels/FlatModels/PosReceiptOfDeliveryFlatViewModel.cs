using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class PosReceiptOfDeliveryFlatViewModel
    {
        public System.Int32 PosReceiptOfDeliveryId { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public System.Guid DeliverId { get; set; }
        public System.String ReceiverName { get; set; }
    }
}
