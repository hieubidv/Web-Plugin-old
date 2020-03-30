
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosStatusTerminal: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String StatusName { get; set; }  
        
		public virtual IList<PosTerminal> PosTerminals { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (StatusName == null)
                            base.AddBrokenRule(PosStatusTerminalBusinessRules.StatusNameRequired);                            
        }
    }
    
        
}


