using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class PosTerminalDetailView
    {
        public System.Int32 TerminalId { get; set; }
        public System.String TerminalIdByHeadQuater { get; set; }
        public System.String InitializeCode { get; set; }
        public System.Int32 PosDeviceDeviceId { get; set; }
        public System.Int32 PosStatusTerminalTerminalStatusId { get; set; }
        public System.Int32 PosSimSimId { get; set; }
        public System.Int32 ConnectType { get; set; }
    }
}
