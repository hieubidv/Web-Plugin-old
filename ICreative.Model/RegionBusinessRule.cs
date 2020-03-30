
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class RegionBusinessRules
    {
          public static readonly BusinessRule RegionIDRequired = new BusinessRule(
                                      "RegionID", "Trường Mã vùng không được để trống");                        
          public static readonly BusinessRule RegionDescriptionRequired = new BusinessRule(
                                      "RegionDescription", "Trường Mô tả vùng không được để trống");                        
    }   
}


