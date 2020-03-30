
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Territory: EntityBase<System.String>, IAggregateRoot
    {
    
        
		public virtual System.String TerritoryDescription { get; set; }  
        
		public virtual IList<Employee> Employees { get; set; }  
        
		public virtual Region Region { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (TerritoryDescription == null)
                            base.AddBrokenRule(TerritoryBusinessRules.TerritoryDescriptionRequired);                            
        }
    }
    
        
}


