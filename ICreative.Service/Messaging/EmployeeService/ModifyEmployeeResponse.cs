
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
using ICreative.Infrastructure.Domain;
namespace ICreative.Services.Messaging
{
    public class ModifyEmployeeResponse
    {
             // public EmployeeView Employee { get; set; }
               public List<BusinessRule> Errors { get; set; }
    }
}
