using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class PosTerminalFlatViewModel
    {
        public System.Int32 TerminalId { get; set; }
        public System.String TerminalIdByHeadQuater { get; set; }
        public System.String InitializeCode { get; set; }
        public System.Int32 DeviceId { get; set; }
        public System.Int32 TerminalStatusId { get; set; }
        public System.Int32 SimId { get; set; }
        public System.Int32 ConnectType { get; set; }
    }
}
