
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class CreateRoomRequest
    {
		public System.String RoomName { get; set; }  
		public System.String Address { get; set; }  
		public System.String PhoneNumber { get; set; }  
		public IList<UserView> Users { get; set; }  
    }
}
