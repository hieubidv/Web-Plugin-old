
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Customer: EntityBase<System.String>, IAggregateRoot
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
        
		public virtual IList<CustomerDemographic> CustomerDemographics { get; set; }  
        
		public virtual IList<Order> Orders { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (CompanyName == null)
                            base.AddBrokenRule(CustomerBusinessRules.CompanyNameRequired);                            
                            if (ContactName == null)
                            base.AddBrokenRule(CustomerBusinessRules.ContactNameRequired);                            
                            if (ContactTitle == null)
                            base.AddBrokenRule(CustomerBusinessRules.ContactTitleRequired);                            
                            if (Address == null)
                            base.AddBrokenRule(CustomerBusinessRules.AddressRequired);                            
                            if (City == null)
                            base.AddBrokenRule(CustomerBusinessRules.CityRequired);                            
                            if (Region == null)
                            base.AddBrokenRule(CustomerBusinessRules.RegionRequired);                            
                            if (PostalCode == null)
                            base.AddBrokenRule(CustomerBusinessRules.PostalCodeRequired);                            
                            if (Country == null)
                            base.AddBrokenRule(CustomerBusinessRules.CountryRequired);                            
                            if (Phone == null)
                            base.AddBrokenRule(CustomerBusinessRules.PhoneRequired);                            
                            if (Fax == null)
                            base.AddBrokenRule(CustomerBusinessRules.FaxRequired);                            
        }
    }
    
        
}


