
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class PosTerminalView
    {
        public System.Int32 TerminalId  { get ; set; }  
		public System.String TerminalIdByHeadQuater { get; set; }  
		public System.String InitializeCode { get; set; }  
		public System.Int32 ConnectType { get; set; }  
		public IList<PosReceiptOfDeliveryView> PosReceiptOfDeliveries { get; set; }  
		public IList<PosReceiptOfTestingView> PosReceiptOfTestings { get; set; }  
		public PosDeviceView PosDevice { get; set; }  
		public PosStatusTerminalView PosStatusTerminal { get; set; }  
		public PosSimView PosSim { get; set; }  
    }
}


