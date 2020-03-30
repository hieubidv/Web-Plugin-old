
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosStatusSim: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String StatusName { get; set; }  
        
		public virtual IList<PosSim> PosSims { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (StatusName == null)
                            base.AddBrokenRule(PosStatusSimBusinessRules.StatusNameRequired);                            
        }
    }
    
        
}


