
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyPosStatusSimRequest
    {

        public System.Int32 StatusId  { get; set; }  
		public System.String StatusName { get; set; }  
		public IList<PosSimView> PosSims { get; set; }  
       
    }
}
