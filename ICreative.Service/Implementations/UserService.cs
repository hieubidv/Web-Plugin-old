
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Infrastructure.Domain;
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
using ICreative.Services.Interfaces;
using ICreative.Services.Mapping;
using ICreative.Services.Messaging;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;

        public UserService(IUserRepository userRepository,
                               IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _uow = uow;
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            CreateUserResponse response = new CreateUserResponse();
            User user = new User();

                  user.UserName = request.UserName;	
                  user.Email = request.Email;	
                  user.Password = request.Password;	
                  user.FirstName = request.FirstName;	
                  user.LastName = request.LastName;	
                  user.PhoneNumber = request.PhoneNumber;	
                  user.BirthDay = request.BirthDay;	
                  user.IpAddress = request.IpAddress;	
                  user.Status = request.Status;	
                  user.CreateDate = request.CreateDate;	
                  user.Roles = request.Roles.ConvertToRoles();   
                  user.Permissions = request.Permissions.ConvertToPermissions();   
                  user.PosReceiptOfDeliveries = request.PosReceiptOfDeliveries.ConvertToPosReceiptOfDeliveries();
                  user.Room = request.Room.ConvertToRoom();                  

            if (user.GetBrokenRules().Count() > 0)
            {
                response.Errors = user.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _userRepository.Add(user);
	            _uow.Commit();  
                    response.Errors = new List<BusinessRule>();
               } catch (Exception ex)
               {
                    List<BusinessRule> errors = new List<BusinessRule>();                    
                    do
                    {
                        if (ex.Message.Contains(@"Violation of UNIQUE KEY constraint 'IX_User'"))
                        {
                            errors.Clear();
                            errors.Add(new BusinessRule("DAL","Đã tồn tại gia trị của trường UserName"));
                            break;
                        }
                            errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
                            ex = ex.InnerException;
                    } while (ex != null);

                    response.Errors = errors;
               }
            } 

            return response;
        }


        public GetUserResponse GetUser(GetUserRequest request)
        {
            GetUserResponse response = new GetUserResponse();

            User user = _userRepository
                                     .FindBy(request.UserId);

            if (user != null)
            {
                response.UserFound = true;
                response.User = user.ConvertToUserView();
            }
            else
                response.UserFound = false;


            return response;
        }

        public ModifyUserResponse ModifyUser(ModifyUserRequest request)
        {
            ModifyUserResponse response = new ModifyUserResponse();

            User user = _userRepository
                                         .FindBy(request.UserId);

               user.Id = request.UserId;
                  user.UserName = request.UserName;	
                  user.Email = request.Email;	
                  user.Password = request.Password;	
                  user.FirstName = request.FirstName;	
                  user.LastName = request.LastName;	
                  user.PhoneNumber = request.PhoneNumber;	
                  user.BirthDay = request.BirthDay;	
                  user.IpAddress = request.IpAddress;	
                  user.Status = request.Status;	
                  user.CreateDate = request.CreateDate;	
                  user.Roles = request.Roles.ConvertToRoles();   
                  user.Permissions = request.Permissions.ConvertToPermissions();   
                  user.PosReceiptOfDeliveries = request.PosReceiptOfDeliveries.ConvertToPosReceiptOfDeliveries();
                  user.Room = request.Room.ConvertToRoom();                  


            if (user.GetBrokenRules().Count() > 0)
            {
                response.Errors = user.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _userRepository.Save(user);
        	        _uow.Commit();
                        response.Errors = new List<BusinessRule>();
                } catch (Exception ex)
                {
	            response.Errors = new List<BusinessRule>();
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
                }                           
            }           


            return response;
        }
        
        public GetAllUserResponse GetAllUsers()
        {
            GetAllUserResponse response = new GetAllUserResponse();

            IEnumerable<User> users = _userRepository
                                     .FindAll();

            if (users != null)
            {
                response.UserFound = true;
                response.Users = users.ConvertToUserViews();   
            }
            else
                response.UserFound = false;


            return response;
        } 
        
        
        public RemoveUserResponse RemoveUser(RemoveUserRequest request)
        {
            RemoveUserResponse response = new RemoveUserResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_userRepository.Remove(request.UserId) > 0)
	            {
        	        response.UserDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
