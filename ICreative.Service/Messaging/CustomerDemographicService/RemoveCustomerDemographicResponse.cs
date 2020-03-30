
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICreative.Services.ViewModels;
using ICreative.Infrastructure.Domain;
namespace ICreative.Services.Messaging
{
    public class RemoveCustomerDemographicResponse
    {
        public bool CustomerDemographicDeleted { get; set; }
        public List<BusinessRule> Errors { get; set; }
    }
}
