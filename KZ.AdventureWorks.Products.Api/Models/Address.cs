using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace KZ.AdventureWorks.Products.Api.Models
{
    public partial class Address
    {
        public Address()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            SalesOrderHeaderBillToAddresses = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddresses = new HashSet<SalesOrderHeader>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceId { get; set; }
        public string PostalCode { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual StateProvince StateProvince { get; set; }
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        [NotMapped]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; set; }
        [NotMapped]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; set; }
    }
}
