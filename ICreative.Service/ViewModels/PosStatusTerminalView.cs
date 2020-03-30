
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class PosStatusTerminalView
    {
        public System.Int32 TerminalStatusId  { get ; set; }  
		public System.String StatusName { get; set; }  
		public IList<PosTerminalView> PosTerminals { get; set; }  
    }
}


