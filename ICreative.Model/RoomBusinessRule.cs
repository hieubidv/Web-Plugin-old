
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class RoomBusinessRules
    {
          public static readonly BusinessRule RoomIdRequired = new BusinessRule(
                                      "RoomId", "Trường Mã phòng không được để trống");                        
          public static readonly BusinessRule RoomNameRequired = new BusinessRule(
                                      "RoomName", "Trường Tên phong không được để trống");                        
          public static readonly BusinessRule AddressRequired = new BusinessRule(
                                      "Address", "Trường Địa chỉ không được để trống");                        
          public static readonly BusinessRule PhoneNumberRequired = new BusinessRule(
                                      "PhoneNumber", "Trường Số điện thoại không được để trống");                        
    }   
}


