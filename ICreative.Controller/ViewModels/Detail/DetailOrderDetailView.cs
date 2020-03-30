using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  	
namespace ICreative.Controllers.ViewModels
{

    public class DetailOrder_OrderDetailView
    {
        public System.Int32 OrderID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime RequiredDate { get; set; }
        public System.DateTime ShippedDate { get; set; }
        public System.Decimal Freight { get; set; }
        public System.String ShipName { get; set; }
        public System.String ShipAddress { get; set; }
        public System.String ShipCity { get; set; }
        public System.String ShipRegion { get; set; }
        public System.String ShipPostalCode { get; set; }
        public System.String ShipCountry { get; set; }
    }

    public class DetailOrder_ProductDetailView
    {
        public System.Int32 ProductID { get; set; }
        public System.String ProductName { get; set; }
        public System.String QuantityPerUnit { get; set; }
        public System.Decimal UnitPrice { get; set; }
        public System.Int16 UnitsInStock { get; set; }
        public System.Int16 UnitsOnOrder { get; set; }
        public System.Int16 ReorderLevel { get; set; }
        public System.Boolean Discontinued { get; set; }
        public System.Int32 CategoryCategoryID { get; set; }
        public System.String CategoryCategoryName { get; set; }
        public System.String CategoryDescription { get; set; }
        public System.Byte[] CategoryPicture { get; set; }
        public System.Int32 SupplierSupplierID { get; set; }
        public System.String SupplierCompanyName { get; set; }
        public System.String SupplierContactName { get; set; }
        public System.String SupplierContactTitle { get; set; }
        public System.String SupplierAddress { get; set; }
        public System.String SupplierCity { get; set; }
        public System.String SupplierRegion { get; set; }
        public System.String SupplierPostalCode { get; set; }
        public System.String SupplierCountry { get; set; }
        public System.String SupplierPhone { get; set; }
        public System.String SupplierFax { get; set; }
        public System.String SupplierHomePage { get; set; }
    }
}
