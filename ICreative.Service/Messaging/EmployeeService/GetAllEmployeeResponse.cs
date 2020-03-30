
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllEmployeeResponse
    {
              public bool EmployeeFound { get; set; }
              public IEnumerable<EmployeeView> Employees { get; set; }
    }
}
