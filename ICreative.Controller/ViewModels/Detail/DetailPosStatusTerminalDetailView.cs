using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  	
namespace ICreative.Controllers.ViewModels
{

    public class DetailPosStatusTerminal_PosStatusTerminalDetailView
    {
        public System.Int32 TerminalStatusId { get; set; }
        public System.String StatusName { get; set; }
    }

    public class DetailPosStatusTerminal_PosTerminalDetailView
    {
        public System.Int32 TerminalId { get; set; }
        public System.String TerminalIdByHeadQuater { get; set; }
        public System.String InitializeCode { get; set; }
        public System.Int32 ConnectType { get; set; }
        public System.Int32 PosDeviceDeviceId { get; set; }
        public System.Int32 PosDeviceBrandId { get; set; }
        public System.String PosDeviceSerialNumber { get; set; }
        public System.String PosDeviceModel { get; set; }
        public System.Int32 PosStatusTerminalTerminalStatusId { get; set; }
        public System.String PosStatusTerminalStatusName { get; set; }
        public System.Int32 PosSimSimId { get; set; }
        public System.String PosSimSimCode { get; set; }
        public System.String PosSimSimPhoneNumber { get; set; }
        public System.DateTime PosSimAddedDate { get; set; }
        public System.Int32 PosSimPosStatusSimStatusId { get; set; }
        public System.String PosSimPosStatusSimStatusName { get; set; }
        public System.Int32 PosSimPosSimProviderSimProviderId { get; set; }
        public System.String PosSimPosSimProviderSimProviderName { get; set; }
    }
}
