using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class OrderDetailView
    {
        public System.Int32 OrderID { get; set; }
        public System.String CustomerCustomerID { get; set; }
        public System.Int32 EmployeeEmployeeID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime RequiredDate { get; set; }
        public System.DateTime ShippedDate { get; set; }
        public System.Int32 ShipperShipperID { get; set; }
        public System.Decimal Freight { get; set; }
        public System.String ShipName { get; set; }
        public System.String ShipAddress { get; set; }
        public System.String ShipCity { get; set; }
        public System.String ShipRegion { get; set; }
        public System.String ShipPostalCode { get; set; }
        public System.String ShipCountry { get; set; }
    }
}
