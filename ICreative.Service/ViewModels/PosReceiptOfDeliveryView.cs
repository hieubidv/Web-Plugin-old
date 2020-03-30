
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class PosReceiptOfDeliveryView
    {
        public System.Int32 PosReceiptOfDeliveryId  { get ; set; }  
		public System.DateTime DeliveryDate { get; set; }  
		public System.String ReceiverName { get; set; }  
		public IList<PosTerminalView> PosTerminals { get; set; }  
		public UserView User { get; set; }  
    }
}


