using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using ICreative.Controllers.ViewModels;
using ICreative.Services.Messaging;
using AutoMapper;
namespace ICreative.Controllers.Mapping
{
    public static class EmployeeFlatViewModelMapper
    {
        public static EmployeeFlatViewModel ConvertToEmployeeFlatViewModel(
                                               this EmployeeView employee)
        {
            return Mapper.Map<EmployeeView,
                              EmployeeFlatViewModel>(employee);
        }
        
        
        public static IEnumerable<EmployeeFlatViewModel> ConvertToEmployeeFlatViewModels(
                                                      this IEnumerable<EmployeeView> employees)
        {
            return Mapper.Map<IEnumerable<EmployeeView>, IEnumerable<EmployeeFlatViewModel>>(employees);
        }               

        public static EmployeeDetailView ConvertToEmployeeDetailView(
                                               this EmployeeView employee)
        {
            return Mapper.Map<EmployeeView,
                              EmployeeDetailView>(employee);
        }
        
        
        public static IEnumerable<EmployeeDetailView> ConvertToEmployeeDetailViews(
                                                      this IEnumerable<EmployeeView> employees)
        {
            return Mapper.Map<IEnumerable<EmployeeView>, IEnumerable<EmployeeDetailView>>(employees);
        }

        public static ModifyEmployeeRequest ConvertToModifyEmployeeRequest(
                                               this EmployeeView employees)
        {
            return Mapper.Map<EmployeeView,
                              ModifyEmployeeRequest>(employees);
        }    	

        public static DetailEmployee_EmployeeDetailView ConvertToDetailEmployee_EmployeeDetailView(
                                       this EmployeeView employees)
        {
            return Mapper.Map<EmployeeView,
                              DetailEmployee_EmployeeDetailView>(employees);
        }

        public static IEnumerable<DetailEmployee_TerritoryDetailView> ConvertToDetailEmployeeTerritoryDetailViews(
                                              this IEnumerable<TerritoryView> territories)
        {
            return Mapper.Map<IEnumerable<TerritoryView>, IEnumerable<DetailEmployee_TerritoryDetailView>>(territories);
        }    	
        public static IEnumerable<DetailEmployee_OrderDetailView> ConvertToDetailEmployeeOrderDetailViews(
                                              this IEnumerable<OrderView> orders)
        {
            return Mapper.Map<IEnumerable<OrderView>, IEnumerable<DetailEmployee_OrderDetailView>>(orders);
        }    	

    }

}
