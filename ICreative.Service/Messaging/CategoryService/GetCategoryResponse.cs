
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetCategoryResponse
    {
              public bool CategoryFound { get; set; }
              public CategoryView Category { get; set; }
    }
}
