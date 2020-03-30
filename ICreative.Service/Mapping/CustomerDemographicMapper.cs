
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class CustomerDemographicMapper
    {
        public static CustomerDemographicView ConvertToCustomerDemographicView(
                                               this CustomerDemographic customerDemographic)
        {
            return Mapper.Map<CustomerDemographic,
                              CustomerDemographicView>(customerDemographic);
        }
        
        
        public static IEnumerable<CustomerDemographicView> ConvertToCustomerDemographicViews(
                                                      this IEnumerable<CustomerDemographic> customerDemographics)
        {
            return Mapper.Map<IEnumerable<CustomerDemographic>, IEnumerable<CustomerDemographicView>>(customerDemographics);
        }
        
        public static CustomerDemographic ConvertToCustomerDemographic(
                                               this CustomerDemographicView customerDemographicView)
        {
            return Mapper.Map<CustomerDemographicView,
                              CustomerDemographic>(customerDemographicView);
        }
        
        
        public static IList<CustomerDemographic> ConvertToCustomerDemographics(
                                                      this IEnumerable<CustomerDemographicView> customerDemographicsView)
        {
            return Mapper.Map<IEnumerable<CustomerDemographicView>, IList<CustomerDemographic>>(customerDemographicsView);
        }        
        
    }

}
