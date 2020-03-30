
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class CategoryView
    {
        public System.Int32 CategoryID  { get ; set; }  
		public System.String CategoryName { get; set; }  
		public System.String Description { get; set; }  
		public System.Byte[] Picture { get; set; }  
		public IList<ProductView> Products { get; set; }  
    }
}


