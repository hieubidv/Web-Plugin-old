
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class ShipperBusinessRules
    {
          public static readonly BusinessRule ShipperIDRequired = new BusinessRule(
                                      "ShipperID", "Trường Mã đơn vị giao hàng không được để trống");                        
          public static readonly BusinessRule CompanyNameRequired = new BusinessRule(
                                      "CompanyName", "Trường Tên công ty không được để trống");                        
          public static readonly BusinessRule PhoneRequired = new BusinessRule(
                                      "Phone", "Trường Số diện thoại không được để trống");                        
    }   
}


