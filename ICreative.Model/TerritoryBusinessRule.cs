
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class TerritoryBusinessRules
    {
          public static readonly BusinessRule TerritoryIDRequired = new BusinessRule(
                                      "TerritoryID", "Trường TerritoryID không được để trống");                        
          public static readonly BusinessRule TerritoryDescriptionRequired = new BusinessRule(
                                      "TerritoryDescription", "Trường TerritoryDescription không được để trống");                        
    }   
}


