
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class CustomerMapper
    {
        public static CustomerView ConvertToCustomerView(
                                               this Customer customer)
        {
            return Mapper.Map<Customer,
                              CustomerView>(customer);
        }
        
        
        public static IEnumerable<CustomerView> ConvertToCustomerViews(
                                                      this IEnumerable<Customer> customers)
        {
            return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerView>>(customers);
        }
        
        public static Customer ConvertToCustomer(
                                               this CustomerView customerView)
        {
            return Mapper.Map<CustomerView,
                              Customer>(customerView);
        }
        
        
        public static IList<Customer> ConvertToCustomers(
                                                      this IEnumerable<CustomerView> customersView)
        {
            return Mapper.Map<IEnumerable<CustomerView>, IList<Customer>>(customersView);
        }        
        
    }

}
