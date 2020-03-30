
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreateRegionRequest
    {
		public System.String RegionDescription { get; set; }  
		public IList<TerritoryView> Territories { get; set; }  
    }
}
