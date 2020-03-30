
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosReceiptOfDelivery: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.DateTime? DeliveryDate { get; set; }  
        
		public virtual System.String ReceiverName { get; set; }  
        
		public virtual IList<PosTerminal> PosTerminals { get; set; }  
        
		public virtual User User { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (DeliveryDate == default(DateTime))
                            base.AddBrokenRule(PosReceiptOfDeliveryBusinessRules.DeliveryDateRequired);                        
                            if (ReceiverName == null)
                            base.AddBrokenRule(PosReceiptOfDeliveryBusinessRules.ReceiverNameRequired);                            
        }
    }
    
        
}


