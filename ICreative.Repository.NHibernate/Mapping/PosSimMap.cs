

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PosSimMap : ClassMap<PosSim>
	{
		public PosSimMap()
		{
			Table("[PosSim]");
            
		    Id(u => u.Id,"SimId").GeneratedBy.Identity().Not.Nullable();
                                                                      ;      
		    Map(u => u.SimCode).Not.Nullable();  
		    Map(u => u.SimPhoneNumber).Not.Nullable();  
		    Map(u => u.AddedDate).Not.Nullable();  
             HasMany(u => u.PosTerminals).KeyColumn("SimId");            
            References(u => u.PosStatusSim).Column("StatusId"); 
            References(u => u.PosSimProvider).Column("SimProviderId"); 
		}
	}
}
 
         

