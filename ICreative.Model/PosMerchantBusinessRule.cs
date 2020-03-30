
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosMerchantBusinessRules
    {
          public static readonly BusinessRule MerchantIdRequired = new BusinessRule(
                                      "MerchantId", "Trường MerchantId không được để trống");                        
          public static readonly BusinessRule MerchantNameRequired = new BusinessRule(
                                      "MerchantName", "Trường MerchantName không được để trống");                        
          public static readonly BusinessRule BusinessNameRequired = new BusinessRule(
                                      "BusinessName", "Trường BusinessName không được để trống");                        
          public static readonly BusinessRule BannerNameRequired = new BusinessRule(
                                      "BannerName", "Trường BannerName không được để trống");                        
          public static readonly BusinessRule MerchantIdByHeadQuaterRequired = new BusinessRule(
                                      "MerchantIdByHeadQuater", "Trường MerchantIdByHeadQuater không được để trống");                        
    }   
}


