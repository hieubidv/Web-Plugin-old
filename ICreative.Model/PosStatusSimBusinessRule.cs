
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosStatusSimBusinessRules
    {
          public static readonly BusinessRule StatusIdRequired = new BusinessRule(
                                      "StatusId", "Trường StatusId không được để trống");                        
          public static readonly BusinessRule StatusNameRequired = new BusinessRule(
                                      "StatusName", "Trường StatusName không được để trống");                        
    }   
}


