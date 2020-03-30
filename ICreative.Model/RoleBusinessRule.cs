
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class RoleBusinessRules
    {
          public static readonly BusinessRule RoleIdRequired = new BusinessRule(
                                      "RoleId", "Trường Mã nhóm quyền không được để trống");                        
          public static readonly BusinessRule RoleNameRequired = new BusinessRule(
                                      "RoleName", "Trường Tên nhóm quyền không được để trống");                        
          public static readonly BusinessRule DescriptionRequired = new BusinessRule(
                                      "Description", "Trường Mô tả không được để trống");                        
    }   
}


