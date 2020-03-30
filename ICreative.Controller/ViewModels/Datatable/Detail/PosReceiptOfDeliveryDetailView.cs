using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class PosReceiptOfDeliveryDetailView
    {
        public System.Int32 PosReceiptOfDeliveryId { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public System.Guid UserUserId { get; set; }
        public System.String ReceiverName { get; set; }
    }
}
