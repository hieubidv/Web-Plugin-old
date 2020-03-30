
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
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _uow;

        public PermissionService(IPermissionRepository permissionRepository,
                               IUnitOfWork uow)
        {
            _permissionRepository = permissionRepository;
            _uow = uow;
        }

        public CreatePermissionResponse CreatePermission(CreatePermissionRequest request)
        {
            CreatePermissionResponse response = new CreatePermissionResponse();
            Permission permission = new Permission();

                  permission.PermissionName = request.PermissionName;	
                  permission.PermissionDescription = request.PermissionDescription;	
                  permission.ControllerName = request.ControllerName;	
                  permission.ActionName = request.ActionName;	
                  permission.IsAnonymous = request.IsAnonymous;	
                  permission.IsDefaultAllow = request.IsDefaultAllow;	
                  permission.Roles = request.Roles.ConvertToRoles();   
                  permission.Users = request.Users.ConvertToUsers();   

            if (permission.GetBrokenRules().Count() > 0)
            {
                response.Errors = permission.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _permissionRepository.Add(permission);
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


        public GetPermissionResponse GetPermission(GetPermissionRequest request)
        {
            GetPermissionResponse response = new GetPermissionResponse();

            Permission permission = _permissionRepository
                                     .FindBy(request.PermissionId);

            if (permission != null)
            {
                response.PermissionFound = true;
                response.Permission = permission.ConvertToPermissionView();
            }
            else
                response.PermissionFound = false;


            return response;
        }

        public ModifyPermissionResponse ModifyPermission(ModifyPermissionRequest request)
        {
            ModifyPermissionResponse response = new ModifyPermissionResponse();

            Permission permission = _permissionRepository
                                         .FindBy(request.PermissionId);

               permission.Id = request.PermissionId;
                  permission.PermissionName = request.PermissionName;	
                  permission.PermissionDescription = request.PermissionDescription;	
                  permission.ControllerName = request.ControllerName;	
                  permission.ActionName = request.ActionName;	
                  permission.IsAnonymous = request.IsAnonymous;	
                  permission.IsDefaultAllow = request.IsDefaultAllow;	
                  permission.Roles = request.Roles.ConvertToRoles();   
                  permission.Users = request.Users.ConvertToUsers();   


            if (permission.GetBrokenRules().Count() > 0)
            {
                response.Errors = permission.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _permissionRepository.Save(permission);
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
        
        public GetAllPermissionResponse GetAllPermissions()
        {
            GetAllPermissionResponse response = new GetAllPermissionResponse();

            IEnumerable<Permission> permissions = _permissionRepository
                                     .FindAll();

            if (permissions != null)
            {
                response.PermissionFound = true;
                response.Permissions = permissions.ConvertToPermissionViews();   
            }
            else
                response.PermissionFound = false;


            return response;
        } 
        
        
        public RemovePermissionResponse RemovePermission(RemovePermissionRequest request)
        {
            RemovePermissionResponse response = new RemovePermissionResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_permissionRepository.Remove(request.PermissionId) > 0)
	            {
        	        response.PermissionDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
