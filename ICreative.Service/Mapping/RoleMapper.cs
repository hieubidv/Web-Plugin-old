
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class RoleMapper
    {
        public static RoleView ConvertToRoleView(
                                               this Role role)
        {
            return Mapper.Map<Role,
                              RoleView>(role);
        }
        
        
        public static IEnumerable<RoleView> ConvertToRoleViews(
                                                      this IEnumerable<Role> roles)
        {
            return Mapper.Map<IEnumerable<Role>, IEnumerable<RoleView>>(roles);
        }
        
        public static Role ConvertToRole(
                                               this RoleView roleView)
        {
            return Mapper.Map<RoleView,
                              Role>(roleView);
        }
        
        
        public static IList<Role> ConvertToRoles(
                                                      this IEnumerable<RoleView> rolesView)
        {
            return Mapper.Map<IEnumerable<RoleView>, IList<Role>>(rolesView);
        }        
        
    }

}
