
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosSim: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String SimCode { get; set; }  
        
		public virtual System.String SimPhoneNumber { get; set; }  
        
		public virtual System.DateTime? AddedDate { get; set; }  
        
		public virtual IList<PosTerminal> PosTerminals { get; set; }  
        
		public virtual PosStatusSim PosStatusSim { get; set; }  
        
		public virtual PosSimProvider PosSimProvider { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (SimCode == null)
                            base.AddBrokenRule(PosSimBusinessRules.SimCodeRequired);                            
                            if (SimPhoneNumber == null)
                            base.AddBrokenRule(PosSimBusinessRules.SimPhoneNumberRequired);                            
                            if (AddedDate == default(DateTime))
                            base.AddBrokenRule(PosSimBusinessRules.AddedDateRequired);                        
        }
    }
    
        
}


