

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PosStatusSimMap : ClassMap<PosStatusSim>
	{
		public PosStatusSimMap()
		{
			Table("[PosStatusSim]");
            
		    Id(u => u.Id,"StatusId").GeneratedBy.Identity().Not.Nullable();
                              ;      
		    Map(u => u.StatusName).Not.Nullable();  
             HasMany(u => u.PosSims).KeyColumn("StatusId");            
		}
	}
}
 
         

