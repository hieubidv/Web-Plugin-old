
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class RegionView
    {
        public System.Int32 RegionID  { get ; set; }  
		public System.String RegionDescription { get; set; }  
		public IList<TerritoryView> Territories { get; set; }  
    }
}


