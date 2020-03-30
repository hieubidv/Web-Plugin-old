
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Order: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.DateTime? OrderDate { get; set; }  
        
		public virtual System.DateTime? RequiredDate { get; set; }  
        
		public virtual System.DateTime? ShippedDate { get; set; }  
        
		public virtual System.Decimal Freight { get; set; }  
        
		public virtual System.String ShipName { get; set; }  
        
		public virtual System.String ShipAddress { get; set; }  
        
		public virtual System.String ShipCity { get; set; }  
        
		public virtual System.String ShipRegion { get; set; }  
        
		public virtual System.String ShipPostalCode { get; set; }  
        
		public virtual System.String ShipCountry { get; set; }  
        
		public virtual IList<Product> Products { get; set; }  
        
		public virtual Employee Employee { get; set; }  
        
		public virtual Customer Customer { get; set; }  
        
		public virtual Shipper Shipper { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (OrderDate == default(DateTime))
                            base.AddBrokenRule(OrderBusinessRules.OrderDateRequired);                        
                            if (RequiredDate == default(DateTime))
                            base.AddBrokenRule(OrderBusinessRules.RequiredDateRequired);                        
                            if (ShippedDate == default(DateTime))
                            base.AddBrokenRule(OrderBusinessRules.ShippedDateRequired);                        
                            if (Freight == 0)
                            base.AddBrokenRule(OrderBusinessRules.FreightRequired);
                            if (ShipName == null)
                            base.AddBrokenRule(OrderBusinessRules.ShipNameRequired);                            
                            if (ShipAddress == null)
                            base.AddBrokenRule(OrderBusinessRules.ShipAddressRequired);                            
                            if (ShipCity == null)
                            base.AddBrokenRule(OrderBusinessRules.ShipCityRequired);                            
                            if (ShipRegion == null)
                            base.AddBrokenRule(OrderBusinessRules.ShipRegionRequired);                            
                            if (ShipPostalCode == null)
                            base.AddBrokenRule(OrderBusinessRules.ShipPostalCodeRequired);                            
                            if (ShipCountry == null)
                            base.AddBrokenRule(OrderBusinessRules.ShipCountryRequired);                            
        }
    }
    
        
}


