
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class RestrictionBusinessRules
    {
          public static readonly BusinessRule RestrictionIdRequired = new BusinessRule(
                                      "RestrictionId", "Trường Mã giới hạn không được để trống");                        
          public static readonly BusinessRule RestrictionNameRequired = new BusinessRule(
                                      "RestrictionName", "Trường Tên giới hạn không được để trống");                        
          public static readonly BusinessRule RequirePermissionRequired = new BusinessRule(
                                      "RequirePermission", "Trường Quyền đòi hởi không được để trống");                        
          public static readonly BusinessRule RestrictionDescriptionRequired = new BusinessRule(
                                      "RestrictionDescription", "Trường Mô tả giới hạn không được để trống");                        
    }   
}


