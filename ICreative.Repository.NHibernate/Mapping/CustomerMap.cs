

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class CustomerMap : ClassMap<Customer>
	{
		public CustomerMap()
		{
			Table("[Customers]");
            
            Id(u => u.Id,"CustomerID").Not.Nullable();
                                                                                                                                  ;      
		    Map(u => u.CompanyName).Not.Nullable();  
		    Map(u => u.ContactName);  
		    Map(u => u.ContactTitle);  
		    Map(u => u.Address);  
		    Map(u => u.City);  
		    Map(u => u.Region);  
		    Map(u => u.PostalCode);  
		    Map(u => u.Country);  
		    Map(u => u.Phone);  
		    Map(u => u.Fax);  
            HasManyToMany(u => u.CustomerDemographics).Table("[CustomerCustomerDemo]").ParentKeyColumn("CustomerID").ChildKeyColumn("CustomerTypeID");             
             HasMany(u => u.Orders).KeyColumn("CustomerID");            
		}
	}
}
 
         

