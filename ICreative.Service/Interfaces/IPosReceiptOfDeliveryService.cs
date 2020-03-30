
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPosReceiptOfDeliveryService
    {
        CreatePosReceiptOfDeliveryResponse CreatePosReceiptOfDelivery(CreatePosReceiptOfDeliveryRequest request);
        GetPosReceiptOfDeliveryResponse GetPosReceiptOfDelivery(GetPosReceiptOfDeliveryRequest request);
        GetAllPosReceiptOfDeliveryResponse GetAllPosReceiptOfDeliveries();
        ModifyPosReceiptOfDeliveryResponse ModifyPosReceiptOfDelivery(ModifyPosReceiptOfDeliveryRequest request);
        RemovePosReceiptOfDeliveryResponse RemovePosReceiptOfDelivery(RemovePosReceiptOfDeliveryRequest request);
    }

}
