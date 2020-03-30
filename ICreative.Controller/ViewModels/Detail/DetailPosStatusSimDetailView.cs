using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  	
namespace ICreative.Controllers.ViewModels
{

    public class DetailPosStatusSim_PosStatusSimDetailView
    {
        public System.Int32 StatusId { get; set; }
        public System.String StatusName { get; set; }
    }

    public class DetailPosStatusSim_PosSimDetailView
    {
        public System.Int32 SimId { get; set; }
        public System.String SimCode { get; set; }
        public System.String SimPhoneNumber { get; set; }
        public System.DateTime AddedDate { get; set; }
        public System.Int32 PosStatusSimStatusId { get; set; }
        public System.String PosStatusSimStatusName { get; set; }
        public System.Int32 PosSimProviderSimProviderId { get; set; }
        public System.String PosSimProviderSimProviderName { get; set; }
    }
}
