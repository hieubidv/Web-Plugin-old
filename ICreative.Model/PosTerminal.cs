
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosTerminal: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String TerminalIdByHeadQuater { get; set; }  
        
		public virtual System.String InitializeCode { get; set; }  
        
		public virtual System.Int32 ConnectType { get; set; }  
        
		public virtual IList<PosReceiptOfDelivery> PosReceiptOfDeliveries { get; set; }  
        
		public virtual IList<PosReceiptOfTesting> PosReceiptOfTestings { get; set; }  
        
		public virtual PosDevice PosDevice { get; set; }  
        
		public virtual PosStatusTerminal PosStatusTerminal { get; set; }  
        
		public virtual PosSim PosSim { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (TerminalIdByHeadQuater == null)
                            base.AddBrokenRule(PosTerminalBusinessRules.TerminalIdByHeadQuaterRequired);                            
                            if (InitializeCode == null)
                            base.AddBrokenRule(PosTerminalBusinessRules.InitializeCodeRequired);                            
                            if (ConnectType == 0)
                            base.AddBrokenRule(PosTerminalBusinessRules.ConnectTypeRequired);
        }
    }
    
        
}


