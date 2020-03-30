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
    public static class CustomerDemographicFlatViewModelMapper
    {
        public static CustomerDemographicFlatViewModel ConvertToCustomerDemographicFlatViewModel(
                                               this CustomerDemographicView customerDemographic)
        {
            return Mapper.Map<CustomerDemographicView,
                              CustomerDemographicFlatViewModel>(customerDemographic);
        }
        
        
        public static IEnumerable<CustomerDemographicFlatViewModel> ConvertToCustomerDemographicFlatViewModels(
                                                      this IEnumerable<CustomerDemographicView> customerDemographics)
        {
            return Mapper.Map<IEnumerable<CustomerDemographicView>, IEnumerable<CustomerDemographicFlatViewModel>>(customerDemographics);
        }               

        public static CustomerDemographicDetailView ConvertToCustomerDemographicDetailView(
                                               this CustomerDemographicView customerDemographic)
        {
            return Mapper.Map<CustomerDemographicView,
                              CustomerDemographicDetailView>(customerDemographic);
        }
        
        
        public static IEnumerable<CustomerDemographicDetailView> ConvertToCustomerDemographicDetailViews(
                                                      this IEnumerable<CustomerDemographicView> customerDemographics)
        {
            return Mapper.Map<IEnumerable<CustomerDemographicView>, IEnumerable<CustomerDemographicDetailView>>(customerDemographics);
        }

        public static ModifyCustomerDemographicRequest ConvertToModifyCustomerDemographicRequest(
                                               this CustomerDemographicView customerDemographics)
        {
            return Mapper.Map<CustomerDemographicView,
                              ModifyCustomerDemographicRequest>(customerDemographics);
        }    	

        public static DetailCustomerDemographic_CustomerDemographicDetailView ConvertToDetailCustomerDemographic_CustomerDemographicDetailView(
                                       this CustomerDemographicView customerDemographics)
        {
            return Mapper.Map<CustomerDemographicView,
                              DetailCustomerDemographic_CustomerDemographicDetailView>(customerDemographics);
        }

        public static IEnumerable<DetailCustomerDemographic_CustomerDetailView> ConvertToDetailCustomerDemographicCustomerDetailViews(
                                              this IEnumerable<CustomerView> customers)
        {
            return Mapper.Map<IEnumerable<CustomerView>, IEnumerable<DetailCustomerDemographic_CustomerDetailView>>(customers);
        }    	

    }

}
