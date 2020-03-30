
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class User: EntityBase<System.Guid>, IAggregateRoot
    {
    
        
		public virtual System.String UserName { get; set; }  
        
		public virtual System.String Email { get; set; }  
        
		public virtual System.String Password { get; set; }  
        
		public virtual System.String FirstName { get; set; }  
        
		public virtual System.String LastName { get; set; }  
        
		public virtual System.String PhoneNumber { get; set; }  
        
		public virtual System.DateTime? BirthDay { get; set; }  
        
		public virtual System.String IpAddress { get; set; }  
        
		public virtual System.Int32 Status { get; set; }  
        
		public virtual System.DateTime? CreateDate { get; set; }  
        
		public virtual IList<Role> Roles { get; set; }  
        
		public virtual IList<Permission> Permissions { get; set; }  
        
		public virtual IList<PosReceiptOfDelivery> PosReceiptOfDeliveries { get; set; }  
        
		public virtual Room Room { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (UserName == null)
                            base.AddBrokenRule(UserBusinessRules.UserNameRequired);                            
                            if (Email == null)
                            base.AddBrokenRule(UserBusinessRules.EmailRequired);                            
                            if (Password == null)
                            base.AddBrokenRule(UserBusinessRules.PasswordRequired);                            
                            if (FirstName == null)
                            base.AddBrokenRule(UserBusinessRules.FirstNameRequired);                            
                            if (LastName == null)
                            base.AddBrokenRule(UserBusinessRules.LastNameRequired);                            
                            if (PhoneNumber == null)
                            base.AddBrokenRule(UserBusinessRules.PhoneNumberRequired);                            
                            if (BirthDay == default(DateTime))
                            base.AddBrokenRule(UserBusinessRules.BirthDayRequired);                        
                            if (IpAddress == null)
                            base.AddBrokenRule(UserBusinessRules.IpAddressRequired);                            
                            if (Status == 0)
                            base.AddBrokenRule(UserBusinessRules.StatusRequired);
                            if (CreateDate == default(DateTime))
                            base.AddBrokenRule(UserBusinessRules.CreateDateRequired);                        
        }
    }
    
        
}


