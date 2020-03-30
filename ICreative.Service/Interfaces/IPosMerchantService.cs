
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPosMerchantService
    {
        CreatePosMerchantResponse CreatePosMerchant(CreatePosMerchantRequest request);
        GetPosMerchantResponse GetPosMerchant(GetPosMerchantRequest request);
        GetAllPosMerchantResponse GetAllPosMerchants();
        ModifyPosMerchantResponse ModifyPosMerchant(ModifyPosMerchantRequest request);
        RemovePosMerchantResponse RemovePosMerchant(RemovePosMerchantRequest request);
    }

}
