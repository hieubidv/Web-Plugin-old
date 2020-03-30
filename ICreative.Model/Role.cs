
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Role: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String RoleName { get; set; }  
        
		public virtual System.String Description { get; set; }  
        
		public virtual IList<Permission> Permissions { get; set; }  
        
		public virtual IList<User> Users { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (RoleName == null)
                            base.AddBrokenRule(RoleBusinessRules.RoleNameRequired);                            
                            if (Description == null)
                            base.AddBrokenRule(RoleBusinessRules.DescriptionRequired);                            
        }
    }
    
        
}


