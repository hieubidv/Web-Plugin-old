using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class PosSimFlatViewModel
    {
        public System.Int32 SimId { get; set; }
        public System.String SimCode { get; set; }
        public System.String SimPhoneNumber { get; set; }
        public System.Int32 StatusId { get; set; }
        public System.DateTime AddedDate { get; set; }
        public System.Int32 SimProviderId { get; set; }
    }
}
