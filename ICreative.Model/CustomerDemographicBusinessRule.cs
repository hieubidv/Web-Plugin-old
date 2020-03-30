
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class CustomerDemographicBusinessRules
    {
          public static readonly BusinessRule CustomerTypeIDRequired = new BusinessRule(
                                      "CustomerTypeID", "Trường Kiểu khách hàng không được để trống");                        
          public static readonly BusinessRule CustomerDescRequired = new BusinessRule(
                                      "CustomerDesc", "Trường Khách hàng mô tả không được để trống");                        
    }   
}


