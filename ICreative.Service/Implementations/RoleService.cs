
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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _uow;

        public RoleService(IRoleRepository roleRepository,
                               IUnitOfWork uow)
        {
            _roleRepository = roleRepository;
            _uow = uow;
        }

        public CreateRoleResponse CreateRole(CreateRoleRequest request)
        {
            CreateRoleResponse response = new CreateRoleResponse();
            Role role = new Role();

                  role.RoleName = request.RoleName;	
                  role.Description = request.Description;	
                  role.Permissions = request.Permissions.ConvertToPermissions();   
                  role.Users = request.Users.ConvertToUsers();   

            if (role.GetBrokenRules().Count() > 0)
            {
                response.Errors = role.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _roleRepository.Add(role);
	            _uow.Commit();  
                    response.Errors = new List<BusinessRule>();
               } catch (Exception ex)
               {
                    List<BusinessRule> errors = new List<BusinessRule>();                    
                    do
                    {
                            errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
                            ex = ex.InnerException;
                    } while (ex != null);

                    response.Errors = errors;
               }
            } 

            return response;
        }


        public GetRoleResponse GetRole(GetRoleRequest request)
        {
            GetRoleResponse response = new GetRoleResponse();

            Role role = _roleRepository
                                     .FindBy(request.RoleId);

            if (role != null)
            {
                response.RoleFound = true;
                response.Role = role.ConvertToRoleView();
            }
            else
                response.RoleFound = false;


            return response;
        }

        public ModifyRoleResponse ModifyRole(ModifyRoleRequest request)
        {
            ModifyRoleResponse response = new ModifyRoleResponse();

            Role role = _roleRepository
                                         .FindBy(request.RoleId);

               role.Id = request.RoleId;
                  role.RoleName = request.RoleName;	
                  role.Description = request.Description;	
                  role.Permissions = request.Permissions.ConvertToPermissions();   
                  role.Users = request.Users.ConvertToUsers();   


            if (role.GetBrokenRules().Count() > 0)
            {
                response.Errors = role.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _roleRepository.Save(role);
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
        
        public GetAllRoleResponse GetAllRoles()
        {
            GetAllRoleResponse response = new GetAllRoleResponse();

            IEnumerable<Role> roles = _roleRepository
                                     .FindAll();

            if (roles != null)
            {
                response.RoleFound = true;
                response.Roles = roles.ConvertToRoleViews();   
            }
            else
                response.RoleFound = false;


            return response;
        } 
        
        
        public RemoveRoleResponse RemoveRole(RemoveRoleRequest request)
        {
            RemoveRoleResponse response = new RemoveRoleResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_roleRepository.Remove(request.RoleId) > 0)
	            {
        	        response.RoleDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
