
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosAddressBusinessRules
    {
          public static readonly BusinessRule AddressIdRequired = new BusinessRule(
                                      "AddressId", "Trường AddressId không được để trống");                        
          public static readonly BusinessRule AddressRequired = new BusinessRule(
                                      "Address", "Trường Địa chỉ không được để trống");                        
    }   
}


