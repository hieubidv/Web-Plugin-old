
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreatePosSimRequest
    {
		public System.String SimCode { get; set; }  
		public System.String SimPhoneNumber { get; set; }  
		public System.DateTime AddedDate { get; set; }  
		public IList<PosTerminalView> PosTerminals { get; set; }  
		public PosStatusSimView PosStatusSim { get; set; }  
		public PosSimProviderView PosSimProvider { get; set; }  
    }
}
