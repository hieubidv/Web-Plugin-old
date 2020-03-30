
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyPosDeviceRequest
    {

        public System.Int32 DeviceId  { get; set; }  
		public System.Int32 BrandId { get; set; }  
		public System.String SerialNumber { get; set; }  
		public System.String Model { get; set; }  
		public IList<PosTerminalView> PosTerminals { get; set; }  
       
    }
}
