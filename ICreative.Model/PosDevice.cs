
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosDevice: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.Int32 BrandId { get; set; }  
        
		public virtual System.String SerialNumber { get; set; }  
        
		public virtual System.String Model { get; set; }  
        
		public virtual IList<PosTerminal> PosTerminals { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (BrandId == 0)
                            base.AddBrokenRule(PosDeviceBusinessRules.BrandIdRequired);
                            if (SerialNumber == null)
                            base.AddBrokenRule(PosDeviceBusinessRules.SerialNumberRequired);                            
                            if (Model == null)
                            base.AddBrokenRule(PosDeviceBusinessRules.ModelRequired);                            
        }
    }
    
        
}


