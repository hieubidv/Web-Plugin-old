
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Employee: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String LastName { get; set; }  
        
		public virtual System.String FirstName { get; set; }  
        
		public virtual System.String Title { get; set; }  
        
		public virtual System.String TitleOfCourtesy { get; set; }  
        
		public virtual System.DateTime? BirthDate { get; set; }  
        
		public virtual System.DateTime? HireDate { get; set; }  
        
		public virtual System.String Address { get; set; }  
        
		public virtual System.String City { get; set; }  
        
		public virtual System.String Region { get; set; }  
        
		public virtual System.String PostalCode { get; set; }  
        
		public virtual System.String Country { get; set; }  
        
		public virtual System.String HomePhone { get; set; }  
        
		public virtual System.String Extension { get; set; }  
        
		public virtual System.Byte[] Photo { get; set; }  
        
		public virtual System.String Notes { get; set; }  
        
		public virtual System.String PhotoPath { get; set; }  
        
		public virtual IList<Territory> Territories { get; set; }  
        
		public virtual IList<Order> Orders { get; set; }  
        
		public virtual Employee EmployeeReference { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (LastName == null)
                            base.AddBrokenRule(EmployeeBusinessRules.LastNameRequired);                            
                            if (FirstName == null)
                            base.AddBrokenRule(EmployeeBusinessRules.FirstNameRequired);                            
                            if (Title == null)
                            base.AddBrokenRule(EmployeeBusinessRules.TitleRequired);                            
                            if (TitleOfCourtesy == null)
                            base.AddBrokenRule(EmployeeBusinessRules.TitleOfCourtesyRequired);                            
                            if (BirthDate == default(DateTime))
                            base.AddBrokenRule(EmployeeBusinessRules.BirthDateRequired);                        
                            if (HireDate == default(DateTime))
                            base.AddBrokenRule(EmployeeBusinessRules.HireDateRequired);                        
                            if (Address == null)
                            base.AddBrokenRule(EmployeeBusinessRules.AddressRequired);                            
                            if (City == null)
                            base.AddBrokenRule(EmployeeBusinessRules.CityRequired);                            
                            if (Region == null)
                            base.AddBrokenRule(EmployeeBusinessRules.RegionRequired);                            
                            if (PostalCode == null)
                            base.AddBrokenRule(EmployeeBusinessRules.PostalCodeRequired);                            
                            if (Country == null)
                            base.AddBrokenRule(EmployeeBusinessRules.CountryRequired);                            
                            if (HomePhone == null)
                            base.AddBrokenRule(EmployeeBusinessRules.HomePhoneRequired);                            
                            if (Extension == null)
                            base.AddBrokenRule(EmployeeBusinessRules.ExtensionRequired);                            
                            if (Notes == null)
                            base.AddBrokenRule(EmployeeBusinessRules.NotesRequired);                            
                            if (PhotoPath == null)
                            base.AddBrokenRule(EmployeeBusinessRules.PhotoPathRequired);                            
        }
    }
    
        
}


