using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class ProductDetailView
    {
        public System.Int32 ProductID { get; set; }
        public System.String ProductName { get; set; }
        public System.Int32 SupplierSupplierID { get; set; }
        public System.Int32 CategoryCategoryID { get; set; }
        public System.String QuantityPerUnit { get; set; }
        public System.Decimal UnitPrice { get; set; }
        public System.Int16 UnitsInStock { get; set; }
        public System.Int16 UnitsOnOrder { get; set; }
        public System.Int16 ReorderLevel { get; set; }
        public System.Boolean Discontinued { get; set; }
    }
}
