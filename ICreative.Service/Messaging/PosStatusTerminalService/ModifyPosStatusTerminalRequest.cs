
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyPosStatusTerminalRequest
    {

        public System.Int32 TerminalStatusId  { get; set; }  
		public System.String StatusName { get; set; }  
		public IList<PosTerminalView> PosTerminals { get; set; }  
       
    }
}
