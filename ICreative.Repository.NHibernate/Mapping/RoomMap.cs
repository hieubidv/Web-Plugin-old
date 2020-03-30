

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class RoomMap : ClassMap<Room>
	{
		public RoomMap()
		{
			Table("[Room]");
            
		    Id(u => u.Id,"RoomId").GeneratedBy.Identity().Not.Nullable();
                                                  ;      
		    Map(u => u.RoomName).Not.Nullable();  
		    Map(u => u.Address);  
		    Map(u => u.PhoneNumber);  
             HasMany(u => u.Users).KeyColumn("RoomId");            
		}
	}
}
 
         

