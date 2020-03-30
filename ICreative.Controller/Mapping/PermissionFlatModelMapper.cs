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
    public static class PermissionFlatViewModelMapper
    {
        public static PermissionFlatViewModel ConvertToPermissionFlatViewModel(
                                               this PermissionView permission)
        {
            return Mapper.Map<PermissionView,
                              PermissionFlatViewModel>(permission);
        }
        
        
        public static IEnumerable<PermissionFlatViewModel> ConvertToPermissionFlatViewModels(
                                                      this IEnumerable<PermissionView> permissions)
        {
            return Mapper.Map<IEnumerable<PermissionView>, IEnumerable<PermissionFlatViewModel>>(permissions);
        }               

        public static PermissionDetailView ConvertToPermissionDetailView(
                                               this PermissionView permission)
        {
            return Mapper.Map<PermissionView,
                              PermissionDetailView>(permission);
        }
        
        
        public static IEnumerable<PermissionDetailView> ConvertToPermissionDetailViews(
                                                      this IEnumerable<PermissionView> permissions)
        {
            return Mapper.Map<IEnumerable<PermissionView>, IEnumerable<PermissionDetailView>>(permissions);
        }

        public static ModifyPermissionRequest ConvertToModifyPermissionRequest(
                                               this PermissionView permissions)
        {
            return Mapper.Map<PermissionView,
                              ModifyPermissionRequest>(permissions);
        }    	

        public static DetailPermission_PermissionDetailView ConvertToDetailPermission_PermissionDetailView(
                                       this PermissionView permissions)
        {
            return Mapper.Map<PermissionView,
                              DetailPermission_PermissionDetailView>(permissions);
        }

        public static IEnumerable<DetailPermission_RoleDetailView> ConvertToDetailPermissionRoleDetailViews(
                                              this IEnumerable<RoleView> roles)
        {
            return Mapper.Map<IEnumerable<RoleView>, IEnumerable<DetailPermission_RoleDetailView>>(roles);
        }    	
        public static IEnumerable<DetailPermission_UserDetailView> ConvertToDetailPermissionUserDetailViews(
                                              this IEnumerable<UserView> users)
        {
            return Mapper.Map<IEnumerable<UserView>, IEnumerable<DetailPermission_UserDetailView>>(users);
        }    	

    }

}
