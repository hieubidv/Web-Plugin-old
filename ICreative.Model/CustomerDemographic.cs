
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class CustomerDemographic: EntityBase<System.String>, IAggregateRoot
    {
    
        
		public virtual System.String CustomerDesc { get; set; }  
        
		public virtual IList<Customer> Customers { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (CustomerDesc == null)
                            base.AddBrokenRule(CustomerDemographicBusinessRules.CustomerDescRequired);                            
        }
    }
    
        
}


