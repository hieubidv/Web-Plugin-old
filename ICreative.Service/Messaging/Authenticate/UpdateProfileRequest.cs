using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Services.Messaging
{
   public class UpdateProfileRequest
    {
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNumber { get; set; }
    }
}
