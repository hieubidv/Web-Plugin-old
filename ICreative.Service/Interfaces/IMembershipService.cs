using ICreative.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Services.Interfaces
{
    public interface IMembershipService
    {
        ValidatePasswordResponse Validate(ValidatePasswordRequest request);
        LockResponse Lock(LockRequest request);
        UnlockResponse Unlock(UnlockRequest request);
        ChangePasswordResponse ChangePassword(ChangePasswordRequest request);
        ResetPasswordResponse ResetPassword(ResetPasswordRequest request);
        UpdateProfileResponse UpdateProfile(UpdateProfileRequest request);
    }
}
