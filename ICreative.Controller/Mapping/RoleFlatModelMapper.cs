using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using ICreative.Controllers.ViewModels;
using ICreative.Services.Messaging;
using AutoMapper;
namespace ICreative.Controllers.Mapping
{
    public static class RoleFlatViewModelMapper
    {
        public static RoleFlatViewModel ConvertToRoleFlatViewModel(
                                               this RoleView role)
        {
            return Mapper.Map<RoleView,
                              RoleFlatViewModel>(role);
        }
        
        
        public static IEnumerable<RoleFlatViewModel> ConvertToRoleFlatViewModels(
                                                      this IEnumerable<RoleView> roles)
        {
            return Mapper.Map<IEnumerable<RoleView>, IEnumerable<RoleFlatViewModel>>(roles);
        }               

        public static RoleDetailView ConvertToRoleDetailView(
                                               this RoleView role)
        {
            return Mapper.Map<RoleView,
                              RoleDetailView>(role);
        }
        
        
        public static IEnumerable<RoleDetailView> ConvertToRoleDetailViews(
                                                      this IEnumerable<RoleView> roles)
        {
            return Mapper.Map<IEnumerable<RoleView>, IEnumerable<RoleDetailView>>(roles);
        }

        public static ModifyRoleRequest ConvertToModifyRoleRequest(
                                               this RoleView roles)
        {
            return Mapper.Map<RoleView,
                              ModifyRoleRequest>(roles);
        }    	

        public static DetailRole_RoleDetailView ConvertToDetailRole_RoleDetailView(
                                       this RoleView roles)
        {
            return Mapper.Map<RoleView,
                              DetailRole_RoleDetailView>(roles);
        }

        public static IEnumerable<DetailRole_PermissionDetailView> ConvertToDetailRolePermissionDetailViews(
                                              this IEnumerable<PermissionView> permissions)
        {
            return Mapper.Map<IEnumerable<PermissionView>, IEnumerable<DetailRole_PermissionDetailView>>(permissions);
        }    	
        public static IEnumerable<DetailRole_UserDetailView> ConvertToDetailRoleUserDetailViews(
                                              this IEnumerable<UserView> users)
        {
            return Mapper.Map<IEnumerable<UserView>, IEnumerable<DetailRole_UserDetailView>>(users);
        }    	

    }

}
