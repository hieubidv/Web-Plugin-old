
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosTerminalBusinessRules
    {
          public static readonly BusinessRule TerminalIdRequired = new BusinessRule(
                                      "TerminalId", "Trường TerminalId không được để trống");                        
          public static readonly BusinessRule TerminalIdByHeadQuaterRequired = new BusinessRule(
                                      "TerminalIdByHeadQuater", "Trường TerminalIdByHeadQuater không được để trống");                        
          public static readonly BusinessRule InitializeCodeRequired = new BusinessRule(
                                      "InitializeCode", "Trường InitializeCode không được để trống");                        
          public static readonly BusinessRule ConnectTypeRequired = new BusinessRule(
                                      "ConnectType", "Trường ConnectType không được để trống");                        
    }   
}


