
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class MenuItemBusinessRules
    {
          public static readonly BusinessRule MenuItemIdRequired = new BusinessRule(
                                      "MenuItemId", "Trường MenuItemId không được để trống");                        
          public static readonly BusinessRule MenuItemNameRequired = new BusinessRule(
                                      "MenuItemName", "Trường MenuItemName không được để trống");                        
          public static readonly BusinessRule ParentIdRequired = new BusinessRule(
                                      "ParentId", "Trường ParentId không được để trống");                        
          public static readonly BusinessRule MenuItemUrlRequired = new BusinessRule(
                                      "MenuItemUrl", "Trường MenuItemUrl không được để trống");                        
    }   
}


