using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Infrastructure.Authentication
{
    public interface ISecurityApplicationService<T>
    {

        void SetCookie(string username, string userData, bool isCookiePersistent);

        string CreateCookieUserData(string username);

        bool ValidateLogin(string username, string password);

        bool LockUser(T userId);

        bool UnlockUser(T userId);

        bool ChangePassword(T userId, string password, string newPassword, string oldPassword, string newPasswordConfirm);

        bool ResetPassword(string email);


    }
}
