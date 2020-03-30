
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosSimProviderBusinessRules
    {
          public static readonly BusinessRule SimProviderIdRequired = new BusinessRule(
                                      "SimProviderId", "Trường SimProviderId không được để trống");                        
          public static readonly BusinessRule SimProviderNameRequired = new BusinessRule(
                                      "SimProviderName", "Trường SimProviderName không được để trống");                        
    }   
}


