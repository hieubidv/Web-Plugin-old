
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IEmployeeService
    {
        CreateEmployeeResponse CreateEmployee(CreateEmployeeRequest request);
        GetEmployeeResponse GetEmployee(GetEmployeeRequest request);
        GetAllEmployeeResponse GetAllEmployees();
        ModifyEmployeeResponse ModifyEmployee(ModifyEmployeeRequest request);
        RemoveEmployeeResponse RemoveEmployee(RemoveEmployeeRequest request);
    }

}
