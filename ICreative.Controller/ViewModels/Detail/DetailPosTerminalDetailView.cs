using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  	
namespace ICreative.Controllers.ViewModels
{

    public class DetailPosTerminal_PosTerminalDetailView
    {
        public System.Int32 TerminalId { get; set; }
        public System.String TerminalIdByHeadQuater { get; set; }
        public System.String InitializeCode { get; set; }
        public System.Int32 ConnectType { get; set; }
    }

    public class DetailPosTerminal_PosReceiptOfDeliveryDetailView
    {
        public System.Int32 PosReceiptOfDeliveryId { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public System.String ReceiverName { get; set; }
        public System.Guid UserUserId { get; set; }
        public System.String UserUserName { get; set; }
        public System.String UserEmail { get; set; }
        public System.String UserPassword { get; set; }
        public System.String UserFirstName { get; set; }
        public System.String UserLastName { get; set; }
        public System.String UserPhoneNumber { get; set; }
        public System.DateTime UserBirthDay { get; set; }
        public System.String UserIpAddress { get; set; }
        public System.Int32 UserStatus { get; set; }
        public System.DateTime UserCreateDate { get; set; }
        public System.Int32 UserRoomRoomId { get; set; }
        public System.String UserRoomRoomName { get; set; }
        public System.String UserRoomAddress { get; set; }
        public System.String UserRoomPhoneNumber { get; set; }
    }
    public class DetailPosTerminal_PosReceiptOfTestingDetailView
    {
        public System.Int32 ReceiptOfTestingId { get; set; }
        public System.DateTime TestDate { get; set; }
        public System.String AgentAName { get; set; }
        public System.String AgentBName { get; set; }
        public System.Int32 PosId { get; set; }
        public System.Int32 PosMerchantMerchantId { get; set; }
        public System.String PosMerchantMerchantName { get; set; }
        public System.String PosMerchantBusinessName { get; set; }
        public System.String PosMerchantBannerName { get; set; }
        public System.String PosMerchantMerchantIdByHeadQuater { get; set; }
        public System.Int32 PosMerchantPosAddressAddressId { get; set; }
        public System.String PosMerchantPosAddressAddress { get; set; }
    }
}
