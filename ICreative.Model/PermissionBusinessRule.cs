
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PermissionBusinessRules
    {
          public static readonly BusinessRule PermissionIdRequired = new BusinessRule(
                                      "PermissionId", "Trường Mã quyền hạn không được để trống");                        
          public static readonly BusinessRule PermissionNameRequired = new BusinessRule(
                                      "PermissionName", "Trường Tên quyền hạn không được để trống");                        
          public static readonly BusinessRule PermissionDescriptionRequired = new BusinessRule(
                                      "PermissionDescription", "Trường Mô tả quyền hạn không được để trống");                        
          public static readonly BusinessRule ControllerNameRequired = new BusinessRule(
                                      "ControllerName", "Trường ControllerName không được để trống");                        
          public static readonly BusinessRule ActionNameRequired = new BusinessRule(
                                      "ActionName", "Trường ActionName không được để trống");                        
          public static readonly BusinessRule IsAnonymousRequired = new BusinessRule(
                                      "IsAnonymous", "Trường IsAnonymous không được để trống");                        
          public static readonly BusinessRule IsDefaultAllowRequired = new BusinessRule(
                                      "IsDefaultAllow", "Trường IsDefaultAllow không được để trống");                        
    }   
}


