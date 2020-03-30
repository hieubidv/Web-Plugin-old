using ICreative.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Services.Messaging
{
    public class ResetPasswordResponse
    {
        public bool Result { get; set; }
        public List<BusinessRule> Errors { get; set; }
    }
}
