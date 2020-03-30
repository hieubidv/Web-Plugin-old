
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Supplier: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String CompanyName { get; set; }  
        
		public virtual System.String ContactName { get; set; }  
        
		public virtual System.String ContactTitle { get; set; }  
        
		public virtual System.String Address { get; set; }  
        
		public virtual System.String City { get; set; }  
        
		public virtual System.String Region { get; set; }  
        
		public virtual System.String PostalCode { get; set; }  
        
		public virtual System.String Country { get; set; }  
        
		public virtual System.String Phone { get; set; }  
        
		public virtual System.String Fax { get; set; }  
        
		public virtual System.String HomePage { get; set; }  
        
		public virtual IList<Product> Products { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (CompanyName == null)
                            base.AddBrokenRule(SupplierBusinessRules.CompanyNameRequired);                            
                            if (ContactName == null)
                            base.AddBrokenRule(SupplierBusinessRules.ContactNameRequired);                            
                            if (ContactTitle == null)
                            base.AddBrokenRule(SupplierBusinessRules.ContactTitleRequired);                            
                            if (Address == null)
                            base.AddBrokenRule(SupplierBusinessRules.AddressRequired);                            
                            if (City == null)
                            base.AddBrokenRule(SupplierBusinessRules.CityRequired);                            
                            if (Region == null)
                            base.AddBrokenRule(SupplierBusinessRules.RegionRequired);                            
                            if (PostalCode == null)
                            base.AddBrokenRule(SupplierBusinessRules.PostalCodeRequired);                            
                            if (Country == null)
                            base.AddBrokenRule(SupplierBusinessRules.CountryRequired);                            
                            if (Phone == null)
                            base.AddBrokenRule(SupplierBusinessRules.PhoneRequired);                            
                            if (Fax == null)
                            base.AddBrokenRule(SupplierBusinessRules.FaxRequired);                            
                            if (HomePage == null)
                            base.AddBrokenRule(SupplierBusinessRules.HomePageRequired);                            
        }
    }
    
        
}


