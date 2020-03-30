

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class RegionMap : ClassMap<Region>
	{
		public RegionMap()
		{
			Table("[Region]");
            
		    Id(u => u.Id,"RegionID").GeneratedBy.Identity().Not.Nullable();
                              ;      
		    Map(u => u.RegionDescription).Not.Nullable();  
             HasMany(u => u.Territories).KeyColumn("RegionID");            
		}
	}
}
 
         

