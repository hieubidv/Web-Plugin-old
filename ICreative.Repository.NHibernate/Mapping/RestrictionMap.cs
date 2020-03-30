

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class RestrictionMap : ClassMap<Restriction>
	{
		public RestrictionMap()
		{
			Table("[Restriction]");
            
		    Id(u => u.Id,"RestrictionId").GeneratedBy.Identity().Not.Nullable();
                                        ;      
		    Map(u => u.RestrictionName).Not.Nullable();  
		    Map(u => u.RequirePermission);  
		    Map(u => u.RestrictionDescription);  
		}
	}
}
 
         

