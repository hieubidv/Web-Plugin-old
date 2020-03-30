
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosReceiptOfDeliveryBusinessRules
    {
          public static readonly BusinessRule PosReceiptOfDeliveryIdRequired = new BusinessRule(
                                      "PosReceiptOfDeliveryId", "Trường PosReceiptOfDeliveryId không được để trống");                        
          public static readonly BusinessRule DeliveryDateRequired = new BusinessRule(
                                      "DeliveryDate", "Trường DeliveryDate không được để trống");                        
          public static readonly BusinessRule ReceiverNameRequired = new BusinessRule(
                                      "ReceiverName", "Trường ReceiverName không được để trống");                        
    }   
}


