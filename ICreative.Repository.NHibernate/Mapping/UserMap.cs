

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class UserMap : ClassMap<User>
	{
		public UserMap()
		{
			Table("[User]");
            
            Id(u => u.Id,"UserId").Not.Nullable();
                                                                                                                                                      ;      
		    Map(u => u.UserName).Not.Nullable();  
		    Map(u => u.Email);  
		    Map(u => u.Password);  
		    Map(u => u.FirstName).Not.Nullable();  
		    Map(u => u.LastName).Not.Nullable();  
		    Map(u => u.PhoneNumber).Not.Nullable();  
		    Map(u => u.BirthDay).Not.Nullable();  
		    Map(u => u.IpAddress);  
		    Map(u => u.Status).Not.Nullable();  
		    Map(u => u.CreateDate).Not.Nullable();  
            HasManyToMany(u => u.Roles).Table("[UserRoles]").ParentKeyColumn("UserId").ChildKeyColumn("RoleId");             
            HasManyToMany(u => u.Permissions).Table("[UserPermissions]").ParentKeyColumn("UserId").ChildKeyColumn("PermissionId");             
             HasMany(u => u.PosReceiptOfDeliveries).KeyColumn("DeliverId");            
            References(u => u.Room).Column("RoomId"); 
		}
	}
}
 
         

