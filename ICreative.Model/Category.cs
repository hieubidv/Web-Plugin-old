
using System;
using System.Collections.Generic;
using ICreative.Infrastructure.Domain;

namespace ICreative.Model
{
    public class Category: EntityBase<System.Int32>, IAggregateRoot
    {
    
        
		public virtual System.String CategoryName { get; set; }  
        
		public virtual System.String Description { get; set; }  
        
		public virtual System.Byte[] Picture { get; set; }  
        
		public virtual IList<Product> Products { get; set; }  
    
        public virtual string ToString()
        {
            return string.Empty;
        }    
        
        protected override void Validate()
        {
                            if (CategoryName == null)
                            base.AddBrokenRule(CategoryBusinessRules.CategoryNameRequired);                            
                            if (Description == null)
                            base.AddBrokenRule(CategoryBusinessRules.DescriptionRequired);                            
        }
    }
    
        
}


