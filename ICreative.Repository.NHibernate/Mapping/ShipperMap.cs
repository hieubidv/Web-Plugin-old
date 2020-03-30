

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class ShipperMap : ClassMap<Shipper>
	{
		public ShipperMap()
		{
			Table("[Shippers]");
            
		    Id(u => u.Id,"ShipperID").GeneratedBy.Identity().Not.Nullable();
                                        ;      
		    Map(u => u.CompanyName).Not.Nullable();  
		    Map(u => u.Phone);  
             HasMany(u => u.Orders).KeyColumn("ShipVia");            
		}
	}
}
 
         

