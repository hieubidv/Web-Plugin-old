
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class EmployeeBusinessRules
    {
          public static readonly BusinessRule EmployeeIDRequired = new BusinessRule(
                                      "EmployeeID", "Trường Mã nhân viên không được để trống");                        
          public static readonly BusinessRule LastNameRequired = new BusinessRule(
                                      "LastName", "Trường Tên không được để trống");                        
          public static readonly BusinessRule FirstNameRequired = new BusinessRule(
                                      "FirstName", "Trường Họ không được để trống");                        
          public static readonly BusinessRule TitleRequired = new BusinessRule(
                                      "Title", "Trường Tiêu đề không được để trống");                        
          public static readonly BusinessRule TitleOfCourtesyRequired = new BusinessRule(
                                      "TitleOfCourtesy", "Trường TitleOfCourtesy không được để trống");                        
          public static readonly BusinessRule BirthDateRequired = new BusinessRule(
                                      "BirthDate", "Trường Ngày sinh không được để trống");                        
          public static readonly BusinessRule HireDateRequired = new BusinessRule(
                                      "HireDate", "Trường Ngày thuê không được để trống");                        
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
          public static readonly BusinessRule HomePhoneRequired = new BusinessRule(
                                      "HomePhone", "Trường Điện thoại cố định không được để trống");                        
          public static readonly BusinessRule ExtensionRequired = new BusinessRule(
                                      "Extension", "Trường Mở rộng không được để trống");                        
          public static readonly BusinessRule PhotoRequired = new BusinessRule(
                                      "Photo", "Trường Ảnh không được để trống");                        
          public static readonly BusinessRule NotesRequired = new BusinessRule(
                                      "Notes", "Trường Notes không được để trống");                        
          public static readonly BusinessRule PhotoPathRequired = new BusinessRule(
                                      "PhotoPath", "Trường Đường dẫn ảnh không được để trống");                        
    }   
}


