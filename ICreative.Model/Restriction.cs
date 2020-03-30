
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Restriction: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String RestrictionName { get; set; }  
        
		public virtual System.String RequirePermission { get; set; }  
        
		public virtual System.String RestrictionDescription { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (RestrictionName == null)
                            base.AddBrokenRule(RestrictionBusinessRules.RestrictionNameRequired);                            
                            if (RequirePermission == null)
                            base.AddBrokenRule(RestrictionBusinessRules.RequirePermissionRequired);                            
                            if (RestrictionDescription == null)
                            base.AddBrokenRule(RestrictionBusinessRules.RestrictionDescriptionRequired);                            
        }
    }
    
        
}


