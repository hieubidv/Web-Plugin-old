
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class CustomerBusinessRules
    {
          public static readonly BusinessRule CustomerIDRequired = new BusinessRule(
                                      "CustomerID", "Trường Mã khách hàng không được để trống");                        
          public static readonly BusinessRule CompanyNameRequired = new BusinessRule(
                                      "CompanyName", "Trường Tên công ty không được để trống");                        
          public static readonly BusinessRule ContactNameRequired = new BusinessRule(
                                      "ContactName", "Trường Tên liên lạc không được để trống");                        
          public static readonly BusinessRule ContactTitleRequired = new BusinessRule(
                                      "ContactTitle", "Trường Tiêu đề liên lạc không được để trống");                        
          public static readonly BusinessRule AddressRequired = new BusinessRule(
                                      "Address", "Trường Địa chỉ không được để trống");                        
          public static readonly BusinessRule CityRequired = new BusinessRule(
                                      "City", "Trường Thành phố không được để trống");                        
          public static readonly BusinessRule RegionRequired = new BusinessRule(
                                      "Region", "Trường Vùng không được để trống");                        
          public static readonly BusinessRule PostalCodeRequired = new BusinessRule(
                                      "PostalCode", "Trường Mã bưu cục không được để trống");                        
          public static readonly BusinessRule CountryRequired = new BusinessRule(
                                      "Country", "Trường Quốc gia không được để trống");                        
          public static readonly BusinessRule PhoneRequired = new BusinessRule(
                                      "Phone", "Trường Số diện thoại không được để trống");                        
          public static readonly BusinessRule FaxRequired = new BusinessRule(
                                      "Fax", "Trường Số Fax không được để trống");                        
    }   
}


