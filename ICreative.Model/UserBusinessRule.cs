
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class UserBusinessRules
    {
          public static readonly BusinessRule UserIdRequired = new BusinessRule(
                                      "UserId", "Trường Mã người dùng không được để trống");                        
          public static readonly BusinessRule UserNameRequired = new BusinessRule(
                                      "UserName", "Trường Tài khoản không được để trống");                        
          public static readonly BusinessRule EmailRequired = new BusinessRule(
                                      "Email", "Trường Dịa chỉ thư không được để trống");                        
          public static readonly BusinessRule PasswordRequired = new BusinessRule(
                                      "Password", "Trường Mật khẩu không được để trống");                        
          public static readonly BusinessRule FirstNameRequired = new BusinessRule(
                                      "FirstName", "Trường Họ không được để trống");                        
          public static readonly BusinessRule LastNameRequired = new BusinessRule(
                                      "LastName", "Trường Tên không được để trống");                        
          public static readonly BusinessRule PhoneNumberRequired = new BusinessRule(
                                      "PhoneNumber", "Trường Số điện thoại không được để trống");                        
          public static readonly BusinessRule BirthDayRequired = new BusinessRule(
                                      "BirthDay", "Trường Ngày sinh không được để trống");                        
          public static readonly BusinessRule IpAddressRequired = new BusinessRule(
                                      "IpAddress", "Trường Địa chỉ IP không được để trống");                        
          public static readonly BusinessRule StatusRequired = new BusinessRule(
                                      "Status", "Trường Trạng thái không được để trống");                        
          public static readonly BusinessRule CreateDateRequired = new BusinessRule(
                                      "CreateDate", "Trường Ngày tạo không được để trống");                        
    }   
}


