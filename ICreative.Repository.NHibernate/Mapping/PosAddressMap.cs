

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PosAddressMap : ClassMap<PosAddress>
	{
		public PosAddressMap()
		{
			Table("[PosAddress]");
            
		    Id(u => u.Id,"AddressId").GeneratedBy.Identity().Not.Nullable();
                              ;      
		    Map(u => u.Address).Not.Nullable();  
             HasMany(u => u.PosMerchants).KeyColumn("AddressId");            
		}
	}
}
 
         

