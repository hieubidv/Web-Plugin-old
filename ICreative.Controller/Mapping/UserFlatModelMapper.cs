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
    public static class UserFlatViewModelMapper
    {
        public static UserFlatViewModel ConvertToUserFlatViewModel(
                                               this UserView user)
        {
            return Mapper.Map<UserView,
                              UserFlatViewModel>(user);
        }
        
        
        public static IEnumerable<UserFlatViewModel> ConvertToUserFlatViewModels(
                                                      this IEnumerable<UserView> users)
        {
            return Mapper.Map<IEnumerable<UserView>, IEnumerable<UserFlatViewModel>>(users);
        }               

        public static UserDetailView ConvertToUserDetailView(
                                               this UserView user)
        {
            return Mapper.Map<UserView,
                              UserDetailView>(user);
        }
        
        
        public static IEnumerable<UserDetailView> ConvertToUserDetailViews(
                                                      this IEnumerable<UserView> users)
        {
            return Mapper.Map<IEnumerable<UserView>, IEnumerable<UserDetailView>>(users);
        }

        public static ModifyUserRequest ConvertToModifyUserRequest(
                                               this UserView users)
        {
            return Mapper.Map<UserView,
                              ModifyUserRequest>(users);
        }    	

        public static DetailUser_UserDetailView ConvertToDetailUser_UserDetailView(
                                       this UserView users)
        {
            return Mapper.Map<UserView,
                              DetailUser_UserDetailView>(users);
        }

        public static IEnumerable<DetailUser_RoleDetailView> ConvertToDetailUserRoleDetailViews(
                                              this IEnumerable<RoleView> roles)
        {
            return Mapper.Map<IEnumerable<RoleView>, IEnumerable<DetailUser_RoleDetailView>>(roles);
        }    	
        public static IEnumerable<DetailUser_PermissionDetailView> ConvertToDetailUserPermissionDetailViews(
                                              this IEnumerable<PermissionView> permissions)
        {
            return Mapper.Map<IEnumerable<PermissionView>, IEnumerable<DetailUser_PermissionDetailView>>(permissions);
        }    	
        public static IEnumerable<DetailUser_PosReceiptOfDeliveryDetailView> ConvertToDetailUserPosReceiptOfDeliveryDetailViews(
                                              this IEnumerable<PosReceiptOfDeliveryView> posReceiptOfDeliveries)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfDeliveryView>, IEnumerable<DetailUser_PosReceiptOfDeliveryDetailView>>(posReceiptOfDeliveries);
        }    	

    }

}
