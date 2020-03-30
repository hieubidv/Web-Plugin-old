
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
namespace ICreative.Services.ViewModels
{
    public class RoomView
    {
        public System.Int32 RoomId  { get ; set; }  
		public System.String RoomName { get; set; }  
		public System.String Address { get; set; }  
		public System.String PhoneNumber { get; set; }  
		public IList<UserView> Users { get; set; }  
    }
}


