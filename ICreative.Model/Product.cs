
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Product: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String ProductName { get; set; }  
        
		public virtual System.String QuantityPerUnit { get; set; }  
        
		public virtual System.Decimal UnitPrice { get; set; }  
        
		public virtual System.Int16 UnitsInStock { get; set; }  
        
		public virtual System.Int16 UnitsOnOrder { get; set; }  
        
		public virtual System.Int16 ReorderLevel { get; set; }  
        
		public virtual System.Boolean Discontinued { get; set; }  
        
		public virtual IList<Order> Orders { get; set; }  
        
		public virtual Category Category { get; set; }  
        
		public virtual Supplier Supplier { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (ProductName == null)
                            base.AddBrokenRule(ProductBusinessRules.ProductNameRequired);                            
                            if (QuantityPerUnit == null)
                            base.AddBrokenRule(ProductBusinessRules.QuantityPerUnitRequired);                            
                            if (UnitPrice == 0)
                            base.AddBrokenRule(ProductBusinessRules.UnitPriceRequired);
                            if (UnitsInStock == 0)
                            base.AddBrokenRule(ProductBusinessRules.UnitsInStockRequired);
                            if (UnitsOnOrder == 0)
                            base.AddBrokenRule(ProductBusinessRules.UnitsOnOrderRequired);
                            if (ReorderLevel == 0)
                            base.AddBrokenRule(ProductBusinessRules.ReorderLevelRequired);
                            if (Discontinued == null)
                            base.AddBrokenRule(ProductBusinessRules.DiscontinuedRequired);                            
        }
    }
    
        
}


