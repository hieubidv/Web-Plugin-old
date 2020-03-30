
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllPosReceiptOfDeliveryResponse
    {
              public bool PosReceiptOfDeliveryFound { get; set; }
              public IEnumerable<PosReceiptOfDeliveryView> PosReceiptOfDeliveries { get; set; }
    }
}
