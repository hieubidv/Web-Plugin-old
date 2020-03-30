
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class EmployeeMapper
    {
        public static EmployeeView ConvertToEmployeeView(
                                               this Employee employee)
        {
            return Mapper.Map<Employee,
                              EmployeeView>(employee);
        }
        
        
        public static IEnumerable<EmployeeView> ConvertToEmployeeViews(
                                                      this IEnumerable<Employee> employees)
        {
            return Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeView>>(employees);
        }
        
        public static Employee ConvertToEmployee(
                                               this EmployeeView employeeView)
        {
            return Mapper.Map<EmployeeView,
                              Employee>(employeeView);
        }
        
        
        public static IList<Employee> ConvertToEmployees(
                                                      this IEnumerable<EmployeeView> employeesView)
        {
            return Mapper.Map<IEnumerable<EmployeeView>, IList<Employee>>(employeesView);
        }        
        
    }

}
