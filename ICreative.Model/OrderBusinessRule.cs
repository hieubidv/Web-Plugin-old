
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class OrderBusinessRules
    {
          public static readonly BusinessRule OrderIDRequired = new BusinessRule(
                                      "OrderID", "Trường Mã đơn hàng không được để trống");                        
          public static readonly BusinessRule OrderDateRequired = new BusinessRule(
                                      "OrderDate", "Trường Ngày đơn hàng không được để trống");                        
          public static readonly BusinessRule RequiredDateRequired = new BusinessRule(
                                      "RequiredDate", "Trường Ngày đòi hỏi không được để trống");                        
          public static readonly BusinessRule ShippedDateRequired = new BusinessRule(
                                      "ShippedDate", "Trường Ngày ship không được để trống");                        
          public static readonly BusinessRule FreightRequired = new BusinessRule(
                                      "Freight", "Trường Freight không được để trống");                        
          public static readonly BusinessRule ShipNameRequired = new BusinessRule(
                                      "ShipName", "Trường Tên đơn vị chuyển không được để trống");                        
          public static readonly BusinessRule ShipAddressRequired = new BusinessRule(
                                      "ShipAddress", "Trường Địa chỉ chuyển không được để trống");                        
          public static readonly BusinessRule ShipCityRequired = new BusinessRule(
                                      "ShipCity", "Trường Thành phố không được để trống");                        
          public static readonly BusinessRule ShipRegionRequired = new BusinessRule(
                                      "ShipRegion", "Trường Vùng không được để trống");                        
          public static readonly BusinessRule ShipPostalCodeRequired = new BusinessRule(
                                      "ShipPostalCode", "Trường Mã bưu cục không được để trống");                        
          public static readonly BusinessRule ShipCountryRequired = new BusinessRule(
                                      "ShipCountry", "Trường Quốc gia không được để trống");                        
    }   
}


