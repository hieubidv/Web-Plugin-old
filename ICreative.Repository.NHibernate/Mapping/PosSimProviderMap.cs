

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PosSimProviderMap : ClassMap<PosSimProvider>
	{
		public PosSimProviderMap()
		{
			Table("[PosSimProvider]");
            
		    Id(u => u.Id,"SimProviderId").GeneratedBy.Identity().Not.Nullable();
                              ;      
		    Map(u => u.SimProviderName).Not.Nullable();  
             HasMany(u => u.PosSims).KeyColumn("SimProviderId");            
		}
	}
}
 
         

