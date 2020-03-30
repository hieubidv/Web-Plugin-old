
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PermissionMapper
    {
        public static PermissionView ConvertToPermissionView(
                                               this Permission permission)
        {
            return Mapper.Map<Permission,
                              PermissionView>(permission);
        }
        
        
        public static IEnumerable<PermissionView> ConvertToPermissionViews(
                                                      this IEnumerable<Permission> permissions)
        {
            return Mapper.Map<IEnumerable<Permission>, IEnumerable<PermissionView>>(permissions);
        }
        
        public static Permission ConvertToPermission(
                                               this PermissionView permissionView)
        {
            return Mapper.Map<PermissionView,
                              Permission>(permissionView);
        }
        
        
        public static IList<Permission> ConvertToPermissions(
                                                      this IEnumerable<PermissionView> permissionsView)
        {
            return Mapper.Map<IEnumerable<PermissionView>, IList<Permission>>(permissionsView);
        }        
        
    }

}
