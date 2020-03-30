
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosAddress: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String Address { get; set; }  
        
		public virtual IList<PosMerchant> PosMerchants { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (Address == null)
                            base.AddBrokenRule(PosAddressBusinessRules.AddressRequired);                            
        }
    }
    
        
}


