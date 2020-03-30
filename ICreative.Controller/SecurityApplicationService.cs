
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICreative.Model;
using ICreative.Infrastructure.Authentication;
using ICreative.Services.Interfaces;
using ICreative.Services.Messaging;
using ICreative.Controllers.ViewModels;
using ICreative.Services.ViewModels;
using Newtonsoft.Json;

namespace ICreative.Controllers
{
    public class SecurityApplicationService : ISecurityApplicationService<Guid>
    {
        private IFormsAuthentication _formsAuthentication;
        private IUserService _userService;
        private IMembershipService _membershipService;
        public SecurityApplicationService(IMembershipService membershipService,IUserService userService, IFormsAuthentication formsAuthentication)
        {
            _userService = userService;
            _formsAuthentication = formsAuthentication;
            _membershipService = membershipService;
        }

        public string CreateCookieUserData(string username)
        {            
            IEnumerable<UserView> users = _userService.GetAllUsers().Users;
            UserView user = users.Where(u => u.UserName == username).FirstOrDefault();

            var serializeModel = new CustomPrincipalSerializeModel();
            serializeModel.UserId = user.UserId;
            serializeModel.FirstName = user.FirstName;
            serializeModel.LastName = user.LastName;
            serializeModel.Permissions = Helper.ConvertRolesToRights(user.Roles);

            return JsonConvert.SerializeObject(serializeModel);
        }


        public void SetCookie(string username, string userData, bool isCookiePersistent)
        {
            _formsAuthentication.SetAuthenticationToken(username, userData, isCookiePersistent);
        }
        public bool ValidateLogin(string username, string password)
        {
            return _formsAuthentication.Authenticate(username, password);
        }

        public bool LockUser(Guid userId)
        {
            LockRequest request = new LockRequest();
            request.UserId = userId;
            return _membershipService.Lock(request).Result;
        }

        public bool UnlockUser(Guid userId)
        {
            UnlockRequest request = new UnlockRequest();
            request.UserId = userId;
            return _membershipService.Unlock(request).Result;
        }

        public bool ChangePassword(Guid userId,string password, string newPassword, string oldPassword,string newPasswordConfirm)
        {
            ChangePasswordRequest request = new ChangePasswordRequest();
            request.UserId = userId;
            request.OldPassword = oldPassword;
            request.NewPassword = newPassword;
            request.NewPasswordConfirm = newPasswordConfirm;
            return _membershipService.ChangePassword(request).Result;
        }

        public bool ResetPassword(string email)
        {
            ResetPasswordRequest request = new ResetPasswordRequest();
            request.Email = email;
            return _membershipService.ResetPassword(request).Result;
        }
    }
}
