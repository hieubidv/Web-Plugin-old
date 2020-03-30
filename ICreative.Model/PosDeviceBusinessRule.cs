
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosDeviceBusinessRules
    {
          public static readonly BusinessRule DeviceIdRequired = new BusinessRule(
                                      "DeviceId", "Trường DeviceId không được để trống");                        
          public static readonly BusinessRule BrandIdRequired = new BusinessRule(
                                      "BrandId", "Trường BrandId không được để trống");                        
          public static readonly BusinessRule SerialNumberRequired = new BusinessRule(
                                      "SerialNumber", "Trường SerialNumber không được để trống");                        
          public static readonly BusinessRule ModelRequired = new BusinessRule(
                                      "Model", "Trường Model không được để trống");                        
    }   
}


