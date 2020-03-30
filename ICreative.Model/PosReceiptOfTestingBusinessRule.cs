
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosReceiptOfTestingBusinessRules
    {
          public static readonly BusinessRule ReceiptOfTestingIdRequired = new BusinessRule(
                                      "ReceiptOfTestingId", "Trường ReceiptOfTestingId không được để trống");                        
          public static readonly BusinessRule TestDateRequired = new BusinessRule(
                                      "TestDate", "Trường TestDate không được để trống");                        
          public static readonly BusinessRule AgentANameRequired = new BusinessRule(
                                      "AgentAName", "Trường AgentAName không được để trống");                        
          public static readonly BusinessRule AgentBNameRequired = new BusinessRule(
                                      "AgentBName", "Trường AgentBName không được để trống");                        
          public static readonly BusinessRule PosIdRequired = new BusinessRule(
                                      "PosId", "Trường PosId không được để trống");                        
    }   
}


