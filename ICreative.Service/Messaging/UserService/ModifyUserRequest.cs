
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class ModifyUserRequest
    {

        public System.Guid UserId  { get; set; }  
		public System.String UserName { get; set; }  
		public System.String Email { get; set; }  
		public System.String Password { get; set; }  
		public System.String FirstName { get; set; }  
		public System.String LastName { get; set; }  
		public System.String PhoneNumber { get; set; }  
		public System.DateTime BirthDay { get; set; }  
		public System.String IpAddress { get; set; }  
		public System.Int32 Status { get; set; }  
		public System.DateTime CreateDate { get; set; }  
		public IList<RoleView> Roles { get; set; }  
		public IList<PermissionView> Permissions { get; set; }  
		public IList<PosReceiptOfDeliveryView> PosReceiptOfDeliveries { get; set; }  
		public RoomView Room { get; set; }  
       
    }
}
