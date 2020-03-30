
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Region: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String RegionDescription { get; set; }  
        
		public virtual IList<Territory> Territories { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (RegionDescription == null)
                            base.AddBrokenRule(RegionBusinessRules.RegionDescriptionRequired);                            
        }
    }
    
        
}


