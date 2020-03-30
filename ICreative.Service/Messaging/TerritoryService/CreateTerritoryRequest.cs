
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreateTerritoryRequest
    {
		public System.String TerritoryDescription { get; set; }  
		public IList<EmployeeView> Employees { get; set; }  
		public RegionView Region { get; set; }  
    }
}
