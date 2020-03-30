
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IUserService
    {
        CreateUserResponse CreateUser(CreateUserRequest request);
        GetUserResponse GetUser(GetUserRequest request);
        GetAllUserResponse GetAllUsers();
        ModifyUserResponse ModifyUser(ModifyUserRequest request);
        RemoveUserResponse RemoveUser(RemoveUserRequest request);
    }

}
