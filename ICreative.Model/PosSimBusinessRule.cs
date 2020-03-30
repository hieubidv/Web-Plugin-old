
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosSimBusinessRules
    {
          public static readonly BusinessRule SimIdRequired = new BusinessRule(
                                      "SimId", "Trường SimId không được để trống");                        
          public static readonly BusinessRule SimCodeRequired = new BusinessRule(
                                      "SimCode", "Trường SimCode không được để trống");                        
          public static readonly BusinessRule SimPhoneNumberRequired = new BusinessRule(
                                      "SimPhoneNumber", "Trường SimPhoneNumber không được để trống");                        
          public static readonly BusinessRule AddedDateRequired = new BusinessRule(
                                      "AddedDate", "Trường AddedDate không được để trống");                        
    }   
}


