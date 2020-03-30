

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class CustomerDemographicMap : ClassMap<CustomerDemographic>
	{
		public CustomerDemographicMap()
		{
			Table("[CustomerDemographics]");
            
            Id(u => u.Id,"CustomerTypeID").Not.Nullable();
                              ;      
		    Map(u => u.CustomerDesc);  
            HasManyToMany(u => u.Customers).Table("[CustomerCustomerDemo]").ParentKeyColumn("CustomerTypeID").ChildKeyColumn("CustomerID");             
		}
	}
}
 
         

