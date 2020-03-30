
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class PosDeviceView
    {
        public System.Int32 DeviceId  { get ; set; }  
		public System.Int32 BrandId { get; set; }  
		public System.String SerialNumber { get; set; }  
		public System.String Model { get; set; }  
		public IList<PosTerminalView> PosTerminals { get; set; }  
    }
}


