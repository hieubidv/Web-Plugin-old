using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{

    public class DetailUser_UserDetailView
    {
        public System.Guid UserId { get; set; }
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
        public System.Int32 RoomRoomId { get; set; }
    }
    public class DetailUser_RoleDetailView
    {
        public System.Int32 RoleId { get; set; }
        public System.String RoleName { get; set; }
        public System.String Description { get; set; }

    }
}
