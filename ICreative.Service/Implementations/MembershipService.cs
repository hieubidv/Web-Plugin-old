using ICreative.Infrastructure.Domain;
using ICreative.Infrastructure.Querying;
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
using ICreative.Services.Interfaces;
using ICreative.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Services.Implementations
{
    public class MembershipService : IMembershipService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _uow;
        public MembershipService(IUserRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public ValidatePasswordResponse Validate(ValidatePasswordRequest request)
        {
            ValidatePasswordResponse response = new ValidatePasswordResponse();

            Query query = new Query();
            query.Add(new Criterion("Password", request.Password, CriteriaOperator.Equal));
            query.QueryOperator = QueryOperator.And;
            query.Add(new Criterion("UserName", request.Username, CriteriaOperator.Equal));
            List<User> users = _repository.FindBy(query).ToList();
            if (users.Count > 0)
            {
                response.Result = true;
            }
            else
            {
                response.Result = false;
            }
            return response;
        }

        public LockResponse Lock(LockRequest request)
        {
            LockResponse response = new LockResponse();
            response.Errors = new List<BusinessRule>();

            User user = _repository
                                     .FindBy(request.UserId);

            if (user != null)
            {
                try
                {
                    user.Status = 0;
                    _repository.Save(user);
                    _uow.Commit();

                    response.Result = true;
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new BusinessRule("Error", ex.Message));
                    response.Result = false;
                }
            }
            else
            {
                response.Result = false;
            }

            return response;

        }

        public UnlockResponse Unlock(UnlockRequest request)
        {
            UnlockResponse response = new UnlockResponse();
            response.Errors = new List<BusinessRule>();

            User user = _repository
                                     .FindBy(request.UserId);

            if (user != null)
            {
                try
                {
                    user.Status = 1;
                    _repository.Save(user);
                    _uow.Commit();

                    response.Result = true;
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new BusinessRule("Error", ex.Message));
                    response.Result = false;
                }
            }
            else
            {
                response.Result = false;
            }

            return response;
        }

        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {
            ChangePasswordResponse response = new ChangePasswordResponse();
            response.Errors = new List<BusinessRule>();

            User user = _repository
                                     .FindBy(request.UserId);

            if (user != null)
            {
                try
                {
                    if (user.Password == request.OldPassword)
                    {
                        if (request.NewPassword == request.NewPasswordConfirm)
                        {
                            user.Password = request.NewPassword;
                            _repository.Save(user);
                            _uow.Commit();
                        }
                        else
                        {
                            response.Errors.Add(new BusinessRule("NewPassword", "New password not matches confirm password"));
                        }

                    }
                    else
                    {
                        response.Errors.Add(new BusinessRule("OldPassword", "Old password not correct"));
                    }
                    response.Result = true;
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new BusinessRule("Error", ex.Message));
                }

            }
            else
            {
                response.Result = false;
            }


            return response;
        }

        public ResetPasswordResponse ResetPassword(ResetPasswordRequest request)
        {
            ResetPasswordResponse response = new ResetPasswordResponse();
            response.Errors = new List<BusinessRule>();

            User user = _repository
                                     .FindAll().Where(u => u.Email == request.Email).FirstOrDefault();

            if (user != null)
            {
                try
                {
                    user.Status = 1;
                    _repository.Save(user);
                    _uow.Commit();

                    response.Result = true;
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new BusinessRule("Error", ex.Message));
                    response.Result = false;
                }
            }
            else
            {
                response.Result = false;
            }

            return response;
        }

        public UpdateProfileResponse UpdateProfile(UpdateProfileRequest request)
        {
            UpdateProfileResponse response = new UpdateProfileResponse();
            response.Errors = new List<BusinessRule>();

            User user = _repository
                                     .FindBy(request.UserId);

            if (user != null)
            {
                try
                {
                    user.FirstName = request.Firstname;
                    user.LastName = request.Lastname;
                    user.PhoneNumber = request.PhoneNumber;
                    user.BirthDay = request.BirthDay;
                    _repository.Save(user);
                    _uow.Commit();

                    response.Result = true;
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new BusinessRule("Error", ex.Message));
                    response.Result = false;
                }
            }
            else
            {
                response.Result = false;
            }

            return response;
        }
    }
}
