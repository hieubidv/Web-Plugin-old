
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosSimProvider: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String SimProviderName { get; set; }  
        
		public virtual IList<PosSim> PosSims { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (SimProviderName == null)
                            base.AddBrokenRule(PosSimProviderBusinessRules.SimProviderNameRequired);                            
        }
    }
    
        
}


