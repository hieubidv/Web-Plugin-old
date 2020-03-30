using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  	
namespace ICreative.Controllers.ViewModels
{

    public class DetailRegion_RegionDetailView
    {
        public System.Int32 RegionID { get; set; }
        public System.String RegionDescription { get; set; }
    }

    public class DetailRegion_TerritoryDetailView
    {
        public System.String TerritoryID { get; set; }
        public System.String TerritoryDescription { get; set; }
        public System.Int32 RegionRegionID { get; set; }
        public System.String RegionRegionDescription { get; set; }
    }
}
