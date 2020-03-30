
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyRegionRequest
    {

        public System.Int32 RegionID  { get; set; }  
		public System.String RegionDescription { get; set; }  
		public IList<TerritoryView> Territories { get; set; }  
       
    }
}
