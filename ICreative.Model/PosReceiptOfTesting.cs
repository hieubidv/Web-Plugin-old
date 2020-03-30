
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosReceiptOfTesting: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.DateTime? TestDate { get; set; }  
        
		public virtual System.String AgentAName { get; set; }  
        
		public virtual System.String AgentBName { get; set; }  
        
		public virtual System.Int32 PosId { get; set; }  
        
		public virtual IList<PosTerminal> PosTerminals { get; set; }  
        
		public virtual PosMerchant PosMerchant { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (TestDate == default(DateTime))
                            base.AddBrokenRule(PosReceiptOfTestingBusinessRules.TestDateRequired);                        
                            if (AgentAName == null)
                            base.AddBrokenRule(PosReceiptOfTestingBusinessRules.AgentANameRequired);                            
                            if (AgentBName == null)
                            base.AddBrokenRule(PosReceiptOfTestingBusinessRules.AgentBNameRequired);                            
                            if (PosId == 0)
                            base.AddBrokenRule(PosReceiptOfTestingBusinessRules.PosIdRequired);
        }
    }
    
        
}


