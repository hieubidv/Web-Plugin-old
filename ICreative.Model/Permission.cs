
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Permission: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String PermissionName { get; set; }  
        
		public virtual System.String PermissionDescription { get; set; }  
        
		public virtual System.String ControllerName { get; set; }  
        
		public virtual System.String ActionName { get; set; }  
        
		public virtual System.Boolean IsAnonymous { get; set; }  
        
		public virtual System.Boolean IsDefaultAllow { get; set; }  
        
		public virtual IList<Role> Roles { get; set; }  
        
		public virtual IList<User> Users { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (PermissionName == null)
                            base.AddBrokenRule(PermissionBusinessRules.PermissionNameRequired);                            
                            if (PermissionDescription == null)
                            base.AddBrokenRule(PermissionBusinessRules.PermissionDescriptionRequired);                            
                            if (ControllerName == null)
                            base.AddBrokenRule(PermissionBusinessRules.ControllerNameRequired);                            
                            if (ActionName == null)
                            base.AddBrokenRule(PermissionBusinessRules.ActionNameRequired);                            
                            if (IsAnonymous == null)
                            base.AddBrokenRule(PermissionBusinessRules.IsAnonymousRequired);                            
                            if (IsDefaultAllow == null)
                            base.AddBrokenRule(PermissionBusinessRules.IsDefaultAllowRequired);                            
        }
    }
    
        
}


