
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class PosMerchant: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String MerchantName { get; set; }  
        
		public virtual System.String BusinessName { get; set; }  
        
		public virtual System.String BannerName { get; set; }  
        
		public virtual System.String MerchantIdByHeadQuater { get; set; }  
        
		public virtual IList<PosReceiptOfTesting> PosReceiptOfTestings { get; set; }  
        
		public virtual PosAddress PosAddress { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (MerchantName == null)
                            base.AddBrokenRule(PosMerchantBusinessRules.MerchantNameRequired);                            
                            if (BusinessName == null)
                            base.AddBrokenRule(PosMerchantBusinessRules.BusinessNameRequired);                            
                            if (BannerName == null)
                            base.AddBrokenRule(PosMerchantBusinessRules.BannerNameRequired);                            
                            if (MerchantIdByHeadQuater == null)
                            base.AddBrokenRule(PosMerchantBusinessRules.MerchantIdByHeadQuaterRequired);                            
        }
    }
    
        
}


