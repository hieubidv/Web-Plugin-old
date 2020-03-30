

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class SupplierMap : ClassMap<Supplier>
	{
		public SupplierMap()
		{
			Table("[Suppliers]");
            
		    Id(u => u.Id,"SupplierID").GeneratedBy.Identity().Not.Nullable();
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
		    Map(u => u.HomePage);  
             HasMany(u => u.Products).KeyColumn("SupplierID");            
		}
	}
}
 
         

