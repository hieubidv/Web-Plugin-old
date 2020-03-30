
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class PosSimView
    {
        public System.Int32 SimId  { get ; set; }  
		public System.String SimCode { get; set; }  
		public System.String SimPhoneNumber { get; set; }  
		public System.DateTime AddedDate { get; set; }  
		public IList<PosTerminalView> PosTerminals { get; set; }  
		public PosStatusSimView PosStatusSim { get; set; }  
		public PosSimProviderView PosSimProvider { get; set; }  
    }
}


