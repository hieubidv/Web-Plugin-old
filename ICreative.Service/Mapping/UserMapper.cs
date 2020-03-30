
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class UserMapper
    {
        public static UserView ConvertToUserView(
                                               this User user)
        {
            return Mapper.Map<User,
                              UserView>(user);
        }
        
        
        public static IEnumerable<UserView> ConvertToUserViews(
                                                      this IEnumerable<User> users)
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserView>>(users);
        }
        
        public static User ConvertToUser(
                                               this UserView userView)
        {
            return Mapper.Map<UserView,
                              User>(userView);
        }
        
        
        public static IList<User> ConvertToUsers(
                                                      this IEnumerable<UserView> usersView)
        {
            return Mapper.Map<IEnumerable<UserView>, IList<User>>(usersView);
        }        
        
    }

}
