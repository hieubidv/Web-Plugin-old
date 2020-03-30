

using FluentNHibernate.Mapping;
using System;
using ICreative.Model;
namespace ICreative.Repository.NHibernate.Mapping
{

	public class RoleMap : ClassMap<Role>
	{
		public RoleMap()
		{
			Table("[Role]");
            
		    Id(u => u.Id,"RoleId").GeneratedBy.Identity().Not.Nullable();
                                                  ;      
		    Map(u => u.RoleName).Not.Nullable();  
		    Map(u => u.Description);  
            HasManyToMany(u => u.Permissions).Table("[RolePermissions]").ParentKeyColumn("RoleId").ChildKeyColumn("PermissionId");             
            HasManyToMany(u => u.Users).Table("[UserRoles]").ParentKeyColumn("RoleId").ChildKeyColumn("UserId");             
		}
	}
}
 
         

