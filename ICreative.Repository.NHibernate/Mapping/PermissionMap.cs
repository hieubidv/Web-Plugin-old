

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class PermissionMap : ClassMap<Permission>
	{
		public PermissionMap()
		{
			Table("[Permission]");
            
		    Id(u => u.Id,"PermissionId").GeneratedBy.Identity().Not.Nullable();
                                                                                          ;      
		    Map(u => u.PermissionName).Not.Nullable();  
		    Map(u => u.PermissionDescription);  
		    Map(u => u.ControllerName);  
		    Map(u => u.ActionName);  
		    Map(u => u.IsAnonymous);  
		    Map(u => u.IsDefaultAllow);  
            HasManyToMany(u => u.Roles).Table("[RolePermissions]").ParentKeyColumn("PermissionId").ChildKeyColumn("RoleId");             
            HasManyToMany(u => u.Users).Table("[UserPermissions]").ParentKeyColumn("PermissionId").ChildKeyColumn("UserId");             
		}
	}
}
 
         

