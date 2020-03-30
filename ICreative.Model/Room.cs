
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Room: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String RoomName { get; set; }  
        
		public virtual System.String Address { get; set; }  
        
		public virtual System.String PhoneNumber { get; set; }  
        
		public virtual IList<User> Users { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (RoomName == null)
                            base.AddBrokenRule(RoomBusinessRules.RoomNameRequired);                            
                            if (Address == null)
                            base.AddBrokenRule(RoomBusinessRules.AddressRequired);                            
                            if (PhoneNumber == null)
                            base.AddBrokenRule(RoomBusinessRules.PhoneNumberRequired);                            
        }
    }
    
        
}


