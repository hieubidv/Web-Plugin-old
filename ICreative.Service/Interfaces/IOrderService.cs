
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IOrderService
    {
        CreateOrderResponse CreateOrder(CreateOrderRequest request);
        GetOrderResponse GetOrder(GetOrderRequest request);
        GetAllOrderResponse GetAllOrders();
        ModifyOrderResponse ModifyOrder(ModifyOrderRequest request);
        RemoveOrderResponse RemoveOrder(RemoveOrderRequest request);
    }

}
