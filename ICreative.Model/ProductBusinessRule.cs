
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class ProductBusinessRules
    {
          public static readonly BusinessRule ProductIDRequired = new BusinessRule(
                                      "ProductID", "Trường Mã sản phẩm không được để trống");                        
          public static readonly BusinessRule ProductNameRequired = new BusinessRule(
                                      "ProductName", "Trường Tên sản phẩm không được để trống");                        
          public static readonly BusinessRule QuantityPerUnitRequired = new BusinessRule(
                                      "QuantityPerUnit", "Trường Số lượng mỗi đơn vị không được để trống");                        
          public static readonly BusinessRule UnitPriceRequired = new BusinessRule(
                                      "UnitPrice", "Trường Gia mỗi đơn vị không được để trống");                        
          public static readonly BusinessRule UnitsInStockRequired = new BusinessRule(
                                      "UnitsInStock", "Trường Số đơn vị trong kho không được để trống");                        
          public static readonly BusinessRule UnitsOnOrderRequired = new BusinessRule(
                                      "UnitsOnOrder", "Trường Số đơn vị trong đơn hàng không được để trống");                        
          public static readonly BusinessRule ReorderLevelRequired = new BusinessRule(
                                      "ReorderLevel", "Trường Mức độ đặt hàng lại không được để trống");                        
          public static readonly BusinessRule DiscontinuedRequired = new BusinessRule(
                                      "Discontinued", "Trường Không tiếp tục không được để trống");                        
    }   
}


