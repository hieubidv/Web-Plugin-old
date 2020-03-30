
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Shipper: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String CompanyName { get; set; }  
        
		public virtual System.String Phone { get; set; }  
        
		public virtual IList<Order> Orders { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (CompanyName == null)
                            base.AddBrokenRule(ShipperBusinessRules.CompanyNameRequired);                            
                            if (Phone == null)
                            base.AddBrokenRule(ShipperBusinessRules.PhoneRequired);                            
        }
    }
    
        
}


