
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyRestrictionRequest
    {

        public System.Int32 RestrictionId  { get; set; }  
		public System.String RestrictionName { get; set; }  
		public System.String RequirePermission { get; set; }  
		public System.String RestrictionDescription { get; set; }  
       
    }
}
