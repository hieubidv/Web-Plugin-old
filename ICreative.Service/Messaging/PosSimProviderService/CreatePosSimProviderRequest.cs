
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreatePosSimProviderRequest
    {
		public System.String SimProviderName { get; set; }  
		public IList<PosSimView> PosSims { get; set; }  
    }
}
