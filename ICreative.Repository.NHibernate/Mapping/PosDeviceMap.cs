

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PosDeviceMap : ClassMap<PosDevice>
	{
		public PosDeviceMap()
		{
			Table("[PosDevice]");
            
		    Id(u => u.Id,"DeviceId").GeneratedBy.Identity().Not.Nullable();
                                                  ;      
		    Map(u => u.BrandId).Not.Nullable();  
		    Map(u => u.SerialNumber).Not.Nullable();  
		    Map(u => u.Model);  
             HasMany(u => u.PosTerminals).KeyColumn("DeviceId");            
		}
	}
}
 
         

