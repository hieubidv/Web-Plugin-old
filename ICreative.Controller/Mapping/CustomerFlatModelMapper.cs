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
    public static class CustomerFlatViewModelMapper
    {
        public static CustomerFlatViewModel ConvertToCustomerFlatViewModel(
                                               this CustomerView customer)
        {
            return Mapper.Map<CustomerView,
                              CustomerFlatViewModel>(customer);
        }
        
        
        public static IEnumerable<CustomerFlatViewModel> ConvertToCustomerFlatViewModels(
                                                      this IEnumerable<CustomerView> customers)
        {
            return Mapper.Map<IEnumerable<CustomerView>, IEnumerable<CustomerFlatViewModel>>(customers);
        }               

        public static CustomerDetailView ConvertToCustomerDetailView(
                                               this CustomerView customer)
        {
            return Mapper.Map<CustomerView,
                              CustomerDetailView>(customer);
        }
        
        
        public static IEnumerable<CustomerDetailView> ConvertToCustomerDetailViews(
                                                      this IEnumerable<CustomerView> customers)
        {
            return Mapper.Map<IEnumerable<CustomerView>, IEnumerable<CustomerDetailView>>(customers);
        }

        public static ModifyCustomerRequest ConvertToModifyCustomerRequest(
                                               this CustomerView customers)
        {
            return Mapper.Map<CustomerView,
                              ModifyCustomerRequest>(customers);
        }    	

        public static DetailCustomer_CustomerDetailView ConvertToDetailCustomer_CustomerDetailView(
                                       this CustomerView customers)
        {
            return Mapper.Map<CustomerView,
                              DetailCustomer_CustomerDetailView>(customers);
        }

        public static IEnumerable<DetailCustomer_CustomerDemographicDetailView> ConvertToDetailCustomerCustomerDemographicDetailViews(
                                              this IEnumerable<CustomerDemographicView> customerDemographics)
        {
            return Mapper.Map<IEnumerable<CustomerDemographicView>, IEnumerable<DetailCustomer_CustomerDemographicDetailView>>(customerDemographics);
        }    	
        public static IEnumerable<DetailCustomer_OrderDetailView> ConvertToDetailCustomerOrderDetailViews(
                                              this IEnumerable<OrderView> orders)
        {
            return Mapper.Map<IEnumerable<OrderView>, IEnumerable<DetailCustomer_OrderDetailView>>(orders);
        }    	

    }

}
