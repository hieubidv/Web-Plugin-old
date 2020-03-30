
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface ICustomerService
    {
        CreateCustomerResponse CreateCustomer(CreateCustomerRequest request);
        GetCustomerResponse GetCustomer(GetCustomerRequest request);
        GetAllCustomerResponse GetAllCustomers();
        ModifyCustomerResponse ModifyCustomer(ModifyCustomerRequest request);
        RemoveCustomerResponse RemoveCustomer(RemoveCustomerRequest request);
    }

}
