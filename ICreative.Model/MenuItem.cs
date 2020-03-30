
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class MenuItem: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String MenuItemName { get; set; }  
        
		public virtual System.Int32 ParentId { get; set; }  
        
		public virtual System.String MenuItemUrl { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (MenuItemName == null)
                            base.AddBrokenRule(MenuItemBusinessRules.MenuItemNameRequired);                            
                            if (ParentId == 0)
                            base.AddBrokenRule(MenuItemBusinessRules.ParentIdRequired);
                            if (MenuItemUrl == null)
                            base.AddBrokenRule(MenuItemBusinessRules.MenuItemUrlRequired);                            
        }
    }
    
        
}


