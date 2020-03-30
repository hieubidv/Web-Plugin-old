using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  	
namespace ICreative.Controllers.ViewModels
{

    public class DetailCustomer_CustomerDetailView
    {
        public System.String CustomerID { get; set; }
        public System.String CompanyName { get; set; }
        public System.String ContactName { get; set; }
        public System.String ContactTitle { get; set; }
        public System.String Address { get; set; }
        public System.String City { get; set; }
        public System.String Region { get; set; }
        public System.String PostalCode { get; set; }
        public System.String Country { get; set; }
        public System.String Phone { get; set; }
        public System.String Fax { get; set; }
    }

    public class DetailCustomer_CustomerDemographicDetailView
    {
        public System.String CustomerTypeID { get; set; }
        public System.String CustomerDesc { get; set; }
    }
    public class DetailCustomer_OrderDetailView
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
        public System.Int32 EmployeeEmployeeID { get; set; }
        public System.String EmployeeLastName { get; set; }
        public System.String EmployeeFirstName { get; set; }
        public System.String EmployeeTitle { get; set; }
        public System.String EmployeeTitleOfCourtesy { get; set; }
        public System.DateTime EmployeeBirthDate { get; set; }
        public System.DateTime EmployeeHireDate { get; set; }
        public System.String EmployeeAddress { get; set; }
        public System.String EmployeeCity { get; set; }
        public System.String EmployeeRegion { get; set; }
        public System.String EmployeePostalCode { get; set; }
        public System.String EmployeeCountry { get; set; }
        public System.String EmployeeHomePhone { get; set; }
        public System.String EmployeeExtension { get; set; }
        public System.Byte[] EmployeePhoto { get; set; }
        public System.String EmployeeNotes { get; set; }
        public System.String EmployeePhotoPath { get; set; }
        public System.Int32 EmployeeEmployeeReferenceEmployeeID { get; set; }
        public System.String EmployeeEmployeeReferenceLastName { get; set; }
        public System.String EmployeeEmployeeReferenceFirstName { get; set; }
        public System.String EmployeeEmployeeReferenceTitle { get; set; }
        public System.String EmployeeEmployeeReferenceTitleOfCourtesy { get; set; }
        public System.DateTime EmployeeEmployeeReferenceBirthDate { get; set; }
        public System.DateTime EmployeeEmployeeReferenceHireDate { get; set; }
        public System.String EmployeeEmployeeReferenceAddress { get; set; }
        public System.String EmployeeEmployeeReferenceCity { get; set; }
        public System.String EmployeeEmployeeReferenceRegion { get; set; }
        public System.String EmployeeEmployeeReferencePostalCode { get; set; }
        public System.String EmployeeEmployeeReferenceCountry { get; set; }
        public System.String EmployeeEmployeeReferenceHomePhone { get; set; }
        public System.String EmployeeEmployeeReferenceExtension { get; set; }
        public System.Byte[] EmployeeEmployeeReferencePhoto { get; set; }
        public System.String EmployeeEmployeeReferenceNotes { get; set; }
        public System.String EmployeeEmployeeReferencePhotoPath { get; set; }
        public System.String CustomerCustomerID { get; set; }
        public System.String CustomerCompanyName { get; set; }
        public System.String CustomerContactName { get; set; }
        public System.String CustomerContactTitle { get; set; }
        public System.String CustomerAddress { get; set; }
        public System.String CustomerCity { get; set; }
        public System.String CustomerRegion { get; set; }
        public System.String CustomerPostalCode { get; set; }
        public System.String CustomerCountry { get; set; }
        public System.String CustomerPhone { get; set; }
        public System.String CustomerFax { get; set; }
        public System.Int32 ShipperShipperID { get; set; }
        public System.String ShipperCompanyName { get; set; }
        public System.String ShipperPhone { get; set; }
    }
}
