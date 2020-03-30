
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosStatusTerminalBusinessRules
    {
          public static readonly BusinessRule TerminalStatusIdRequired = new BusinessRule(
                                      "TerminalStatusId", "Trường TerminalStatusId không được để trống");                        
          public static readonly BusinessRule StatusNameRequired = new BusinessRule(
                                      "StatusName", "Trường StatusName không được để trống");                        
    }   
}


