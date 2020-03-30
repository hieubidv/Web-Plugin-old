
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class CategoryBusinessRules
    {
          public static readonly BusinessRule CategoryIDRequired = new BusinessRule(
                                      "CategoryID", "Trường Mã loại sản phẩm không được để trống");                        
          public static readonly BusinessRule CategoryNameRequired = new BusinessRule(
                                      "CategoryName", "Trường Tên loại sản phẩm không được để trống");                        
          public static readonly BusinessRule DescriptionRequired = new BusinessRule(
                                      "Description", "Trường Mô tả không được để trống");                        
          public static readonly BusinessRule PictureRequired = new BusinessRule(
                                      "Picture", "Trường Ảnh không được để trống");                        
    }   
}


