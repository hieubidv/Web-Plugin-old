
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface ICustomerDemographicService
    {
        CreateCustomerDemographicResponse CreateCustomerDemographic(CreateCustomerDemographicRequest request);
        GetCustomerDemographicResponse GetCustomerDemographic(GetCustomerDemographicRequest request);
        GetAllCustomerDemographicResponse GetAllCustomerDemographics();
        ModifyCustomerDemographicResponse ModifyCustomerDemographic(ModifyCustomerDemographicRequest request);
        RemoveCustomerDemographicResponse RemoveCustomerDemographic(RemoveCustomerDemographicRequest request);
    }

}
