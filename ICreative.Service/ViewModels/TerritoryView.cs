
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class TerritoryView
    {
        public System.String TerritoryID  { get ; set; }  
		public System.String TerritoryDescription { get; set; }  
		public IList<EmployeeView> Employees { get; set; }  
		public RegionView Region { get; set; }  
    }
}


