
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreatePosReceiptOfTestingRequest
    {
		public System.DateTime TestDate { get; set; }  
		public System.String AgentAName { get; set; }  
		public System.String AgentBName { get; set; }  
		public System.Int32 PosId { get; set; }  
		public IList<PosTerminalView> PosTerminals { get; set; }  
		public PosMerchantView PosMerchant { get; set; }  
    }
}
