
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class PosSimProviderView
    {
        public System.Int32 SimProviderId  { get ; set; }  
		public System.String SimProviderName { get; set; }  
		public IList<PosSimView> PosSims { get; set; }  
    }
}


